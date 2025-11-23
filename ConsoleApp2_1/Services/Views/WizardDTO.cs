namespace ConsoleApp1;
using System.Collections.Generic;

public class WizardDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string House { get; set; }
    public int Rating { get; set; }
    public string WizardType { get; set; }
    public List<string> SpellNames { get; set; }
}