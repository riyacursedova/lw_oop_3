namespace ConsoleApp1;
using System.Collections.Generic;
public class DeathMatchDuel : BaseDuel
{
    public DeathMatchDuel() : base("Серйозна (Deathmatch)") { }

    public override int GetRatingStake() => 100;

    public override void ConductDuel(WizardEntity wizard1, WizardEntity wizard2, List<SpellEntity> spells1, List<SpellEntity> spells2)
    {
        TurnLog.Add($"\n=== Початок {DuelType} дуелі ===");
        TurnLog.Add($"На кону: {GetRatingStake()} рейтингових балів");

        int turn = 1;
        while (wizard1.Health > 0 && wizard2.Health > 0)
        {
            string turnLog = $"Хід {turn}: ";
            
            SpellEntity spell1 = CastRandomSpell(spells1);
            if (spell1 != null)
            {
                int damage = CalculateDamage(spell1, wizard1);
                turnLog += $"{wizard1.Name} → {spell1.Name}. ";
                ApplyDamage(wizard2, damage, wizard1.Name, spell1.Name);
            }

            if (wizard2.Health <= 0) { Winner = wizard1; Loser = wizard2; break; }

            SpellEntity spell2 = CastRandomSpell(spells2);
            if (spell2 != null)
            {
                int damage = CalculateDamage(spell2, wizard2);
                turnLog += $"{wizard2.Name} → {spell2.Name}.";
                ApplyDamage(wizard1, damage, wizard2.Name, spell2.Name);
            }
            
            TurnLog.Add(turnLog);
            if (wizard1.Health <= 0) { Winner = wizard2; Loser = wizard1; break; }
            turn++;
        }
        TurnLog.Add($"Переможець: {Winner.Name}!");
    }
}