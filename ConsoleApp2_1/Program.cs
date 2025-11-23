using System;
using System.Text;
using System.Collections.Generic; 
using System.Linq;             

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("ДУЕЛЬНИЙ КЛУБ");
        
        var dbContext = new HogwartsDbContext();
        
        var wizardRepo = new WizardRepository(dbContext);
        var spellRepo = new SpellRepository(dbContext);
        var historyRepo = new DuelHistoryRepository(dbContext);
        
        var wizardService = new WizardService(wizardRepo, spellRepo);
        var duelService = new DuelService(wizardRepo, spellRepo, historyRepo);
        
        var factory = new DuelFactory();
        

        Console.WriteLine("\nСПИСОК МАГІВ");
        var wizards = wizardService.GetAllWizards();
        foreach (var w in wizards)
        {
            Console.WriteLine($"ID: {w.Id}, Ім'я: {w.Name}, Тип: {w.WizardType}, Рейтинг: {w.Rating}");
            Console.WriteLine($"  Закляття: {string.Join(", ", w.SpellNames)}");
        }
        
        int dracoId = wizards.First(w => w.Name.Contains("Драко")).Id;
        int nevilleId = wizards.First(w => w.Name.Contains("Невілл")).Id;
        
        Console.WriteLine("\n--- 1. Серйозна дуель (Deathmatch): ---");
        BaseDuel deathmatch = factory.CreateDuel("deathmatch"); 
        DuelResultDTO result1 = duelService.HostDuel(dracoId, nevilleId, deathmatch);
        Console.WriteLine($"\nРезультат: {result1.WinnerName} переміг! +{result1.RatingChange} балів.");

        
        Console.WriteLine("\n--- 2. Швидка дуель: ---");
        BaseDuel speedDuel = factory.CreateDuel("speed");
        DuelResultDTO result2 = duelService.HostDuel(dracoId, nevilleId, speedDuel);
        Console.WriteLine($"\nРезультат: {result2.WinnerName} переміг! +{result2.RatingChange} балів.");

        
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine($"ІСТОРІЯ ДУЕЛЕЙ: {wizards[0].Name} ");
        var dracoHistory = duelService.GetDuelHistory(dracoId);
        foreach (var h in dracoHistory)
        {
            Console.WriteLine($"Дуель #{h.DuelID}: {h.Result} проти {h.OpponentName})");
        }

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine($"ІСТОРІЯ ДУЕЛЕЙ: {wizards[1].Name} ");
        var nevilleHistory = duelService.GetDuelHistory(nevilleId);
        foreach (var h in nevilleHistory)
        {
            Console.WriteLine($"Дуель #{h.DuelID}: {h.Result} проти {h.OpponentName})");
        }
        
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("ОНОВЛЕНІ РЕЙТИНГИ ");
        var updatedWizards = wizardService.GetAllWizards();
        foreach (var w in updatedWizards)
        {
            Console.WriteLine($"Ім'я: {w.Name}, Новий Рейтинг: {w.Rating}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу . . .");
        Console.ReadKey();
    }
}