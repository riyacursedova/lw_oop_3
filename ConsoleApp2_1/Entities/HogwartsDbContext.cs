namespace ConsoleApp1;
using System.Collections.Generic;

public class HogwartsDbContext
{
    public List<WizardEntity> Wizards { get; set; }
    public List<SpellEntity> Spells { get; set; }
    public List<WizardSpell> WizardSpells { get; set; }
    public List<DuelHistory> DuelHistories { get; set; }
    
    public HogwartsDbContext()
    {
        Wizards = new List<WizardEntity>();
        Spells = new List<SpellEntity>();
        WizardSpells = new List<WizardSpell>();
        DuelHistories = new List<DuelHistory>();
        
        SeedData();
    }
    // Started data
    private void SeedData()
    {
        var stupify = new SpellEntity { Id = 1, Name = "Ступефай", BaseDamage = 15, Effect = Effect.Stunning };
        var expelliarmus = new SpellEntity { Id = 2, Name = "Експеліармус", BaseDamage = 20, Effect = Effect.Disarming };
        var crucio = new SpellEntity { Id = 3, Name = "Круціо", BaseDamage = 30, Effect = Effect.Damage };
        var protego = new SpellEntity { Id = 4, Name = "Протеґо", BaseDamage = 10, Effect = Effect.Stunning };
        Spells.Add(stupify);
        Spells.Add(expelliarmus);
        Spells.Add(crucio);
        Spells.Add(protego);
        
        var draco = new WizardEntity 
        { 
            Id = 1, Name = "Драко Малфой", House = "Слизерин", 
            Health = 100, Rating = 1500, WizardType = "Aggressive" 
        };
        var neville = new WizardEntity 
        { 
            Id = 2, Name = "Невілл Лонгботом", House = "Грифіндор", 
            Health = 100, Rating = 1450, WizardType = "Defense" 
        };
        Wizards.AddRange(new[] { draco, neville });
        
        WizardSpells.Add(new WizardSpell { Id = 1, WizardId = draco.Id, SpellId = crucio.Id });
        WizardSpells.Add(new WizardSpell { Id = 2, WizardId = draco.Id, SpellId = expelliarmus.Id });

        WizardSpells.Add(new WizardSpell { Id = 3, WizardId = neville.Id, SpellId = protego.Id });
        WizardSpells.Add(new WizardSpell { Id = 4, WizardId = neville.Id, SpellId = stupify.Id });
    }
}