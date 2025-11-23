namespace ConsoleApp1;

public interface IDuelHistoryRepository // Description methods
{
    void Create(DuelHistory history);
    List<DuelHistory> GetHistoryForWizard(int wizardId);
}