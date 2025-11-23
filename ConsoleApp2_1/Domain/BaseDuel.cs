namespace ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class BaseDuel
{
    public string DuelType { get; protected set; }
    public List<string> TurnLog { get; protected set; }
    public WizardEntity Winner { get; protected set; }
    public WizardEntity Loser { get; protected set; }

    public abstract int GetRatingStake();
    public abstract void ConductDuel(WizardEntity wizard1, WizardEntity wizard2, List<SpellEntity> spells1, List<SpellEntity> spells2);

    protected BaseDuel(string duelType)
    {
        DuelType = duelType;
        TurnLog = new List<string>();
    }
    

    protected SpellEntity CastRandomSpell(List<SpellEntity> knownSpells)
    {
        if (knownSpells == null || knownSpells.Count == 0) return null;
        Random rand = new Random();
        return knownSpells[rand.Next(knownSpells.Count)];
    }

    protected int CalculateDamage(SpellEntity spell, WizardEntity caster)
    {
        if (spell == null) return 0;
        
        if (caster.WizardType == "Aggressive")
        {
            return spell.BaseDamage + 5; 
        }
        return spell.BaseDamage;
    }

    protected void ApplyDamage(WizardEntity target, int damage, string attackerName, string spellName)
    {
        int finalDamage = damage;
        

        if (target.WizardType == "Defense")
        {
            finalDamage = (int)(damage * 0.80);
        }
        
        target.Health -= finalDamage;
        if (target.Health < 0) target.Health = 0;
        
        string log = $" {attackerName} ({spellName}) завдає {finalDamage} шкоди {target.Name}.";
        log += $" (Тип: {target.WizardType}). Здоров'я: {target.Health}";
        TurnLog.Add(log);
        Console.WriteLine(log); 
    }
}