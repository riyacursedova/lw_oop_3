namespace ConsoleApp1;
using System.Collections.Generic;

public class DuelResultDTO
{
    public string WinnerName { get; set; }
    public string LoserName { get; set; }
    public int RatingChange { get; set; }
    public List<string> Log { get; set; }
}