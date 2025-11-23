namespace ConsoleApp1;
using System;

public class DuelFactory
{
    public BaseDuel CreateDuel(string duelType)
    {
        if (duelType == "deathmatch")
        {
            Console.WriteLine(" Фабрика: створено серйозну дуель");
            return new DeathMatchDuel(); 
        }
        else if (duelType == "speed") 
        {
            Console.WriteLine(" Фабрика: створено швидку дуель");
            return new SpeedDuel(); 
        }
        else
        {
            throw new ArgumentException($"Невідомий тип дуелі: {duelType}");
        }
    }
}