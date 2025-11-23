namespace ConsoleApp1;
using System.Collections.Generic;

public interface IDuelService
{

    DuelResultDTO HostDuel(int wizard1Id, int wizard2Id, BaseDuel duelLogic);
    List<DuelHistoryDTO> GetDuelHistory(int wizardId);
}