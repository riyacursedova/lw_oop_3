namespace ConsoleApp1;

public class WizardSpell
{
    public int Id { get; set; }
    public int WizardId { get; set; } // -> WizardEntity
    public int SpellId { get; set; }  // -> SpellEntity
}