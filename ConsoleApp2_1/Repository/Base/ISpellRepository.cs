namespace ConsoleApp1;

public interface ISpellRepository // Description methods
{
    SpellEntity GetById(int id);
    List<SpellEntity> GetSpellsForWizard(int wizardId);
}