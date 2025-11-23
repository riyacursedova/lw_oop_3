namespace ConsoleApp1
{
    using System;
    
    public static class DuelHistoryMapper
    {
        public static DuelHistoryDTO ToDto(DuelHistory entity, int currentWizardId, string opponentName)
        {
            string result = entity.WinnerId == currentWizardId ? "Перемога" : "Поразка";
            
            return new DuelHistoryDTO
            {
                DuelID = entity.Id,
                Result = result,
                OpponentName = opponentName,
            };
        }
    }
}