namespace ConsoleApp1;
using System;

public class DuelHistoryDTO
{
    public int DuelID { get; set; }
    public string Result { get; set; } // -> Win/Lose
    public string OpponentName { get; set; }
}