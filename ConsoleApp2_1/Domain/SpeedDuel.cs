namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class SpeedDuel : BaseDuel
    {
        public SpeedDuel() : base("Швидка") { }

        public override int GetRatingStake() => 25;
        public override void ConductDuel(WizardEntity wizard1, WizardEntity wizard2, List<SpellEntity> spells1, List<SpellEntity> spells2)
        {
            TurnLog.Add($"\n=== Початок {DuelType} дуелі (макс 5 ходів) ===");
            TurnLog.Add($"На кону: {GetRatingStake()} рейтингових балів");

            int maxTurns = 5;
            for (int turn = 1; turn <= maxTurns; turn++)
            {
                string turnLog = $"Швидкий хід {turn}: ";
                
                SpellEntity spell1 = CastRandomSpell(spells1);
                SpellEntity spell2 = CastRandomSpell(spells2);

                if (spell1 != null)
                {
                    int damage = CalculateDamage(spell1, wizard1);
                    turnLog += $"{wizard1.Name} → {spell1.Name}. ";
                    ApplyDamage(wizard2, damage, wizard1.Name, spell1.Name);
                }
                
                if (spell2 != null)
                {
                    int damage = CalculateDamage(spell2, wizard2);
                    turnLog += $"{wizard2.Name} → {spell2.Name}. ";
                    ApplyDamage(wizard1, damage, wizard2.Name, spell2.Name);
                }
                
                TurnLog.Add(turnLog);
                
                if (wizard1.Health <= 0) { Winner = wizard2; Loser = wizard1; break; }
                if (wizard2.Health <= 0) { Winner = wizard1; Loser = wizard2; break; }
            }
            
            if (Winner == null) 
            {
                Winner = wizard1.Health > wizard2.Health ? wizard1 : wizard2;
                Loser = wizard1.Health > wizard2.Health ? wizard2 : wizard1;
                TurnLog.Add($"Час вийшов! Перемагає {Winner.Name} за рахунок більшого здоров'я!");
            }
            TurnLog.Add($"Переможець: {Winner.Name}!");
        }
    }
}