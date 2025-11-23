namespace ConsoleApp1;
using System.Collections.Generic;
using System.Linq;

public class DuelService : IDuelService
{
    private readonly IWizardRepository _wizardRepo;
    private readonly ISpellRepository _spellRepo;
    private readonly IDuelHistoryRepository _historyRepo;

    public DuelService(IWizardRepository wizardRepo, ISpellRepository spellRepo, IDuelHistoryRepository historyRepo)
    {
        _wizardRepo = wizardRepo;
        _spellRepo = spellRepo;
        _historyRepo = historyRepo;
    }
    
    public DuelResultDTO HostDuel(int wizard1Id, int wizard2Id, BaseDuel duelLogic)
    {
        var wizard1 = _wizardRepo.GetById(wizard1Id);
        var wizard2 = _wizardRepo.GetById(wizard2Id);
        var spells1 = _spellRepo.GetSpellsForWizard(wizard1Id);
        var spells2 = _spellRepo.GetSpellsForWizard(wizard2Id);
        
        wizard1.Health = 100;
        wizard2.Health = 100;
        
        duelLogic.ConductDuel(wizard1, wizard2, spells1, spells2);
        
        var winner = duelLogic.Winner;
        var loser = duelLogic.Loser;
        int ratingStake = duelLogic.GetRatingStake();
        
        winner.Rating += ratingStake;
        loser.Rating -= ratingStake;
        
        _wizardRepo.Update(winner);
        _wizardRepo.Update(loser);
        
        var historyEntry = new DuelHistory
        {
            WinnerId = winner.Id,
            LoserId = loser.Id,
            TurnLog = string.Join("\n", duelLogic.TurnLog) 
        };
        _historyRepo.Create(historyEntry);
        
        return new DuelResultDTO
        {
            WinnerName = winner.Name,
            LoserName = loser.Name,
            RatingChange = ratingStake,
            Log = duelLogic.TurnLog
        };
    }

    public List<DuelHistoryDTO> GetDuelHistory(int wizardId)
    {
        var historyEntities = _historyRepo.GetHistoryForWizard(wizardId);
        var wizardName = _wizardRepo.GetById(wizardId)?.Name;

        var dtos = new List<DuelHistoryDTO>();
        foreach (var entry in historyEntities)
        {
            string result = entry.WinnerId == wizardId ? "Перемога" : "Поразка"; // Result
            int opponentId = entry.WinnerId == wizardId ? entry.LoserId : entry.WinnerId; // Search opponent
            string opponentName = _wizardRepo.GetById(opponentId)?.Name ?? "Невідомий"; // ID -> Name
            
            dtos.Add(new DuelHistoryDTO
            {
                DuelID = entry.Id,
                Result = result,
                OpponentName = opponentName,
            });
        }
        return dtos;
    }
}