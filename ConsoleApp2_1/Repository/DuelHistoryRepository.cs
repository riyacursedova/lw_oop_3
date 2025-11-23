namespace ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

public class DuelHistoryRepository : IDuelHistoryRepository
{
    private readonly HogwartsDbContext _context;

    public DuelHistoryRepository(HogwartsDbContext context)
    {
        _context = context;
    }

    public void Create(DuelHistory history)
    {
        history.Id = _context.DuelHistories.Count + 1;
        _context.DuelHistories.Add(history);
    }

    public List<DuelHistory> GetHistoryForWizard(int wizardId)
    {
        return _context.DuelHistories
            .Where(h => h.WinnerId == wizardId || h.LoserId == wizardId)
            .ToList();
    }
}