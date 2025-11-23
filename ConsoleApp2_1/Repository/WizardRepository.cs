namespace ConsoleApp1;
using System.Collections.Generic;
using System.Linq;

public class WizardRepository : IWizardRepository
{
    private readonly HogwartsDbContext _context;

    public WizardRepository(HogwartsDbContext context)
    {
        _context = context;
    }

    public WizardEntity GetById(int id)
    {
        return _context.Wizards.FirstOrDefault(w => w.Id == id);
    }

    public List<WizardEntity> GetAll()
    {
        return _context.Wizards;
    }

    public void Update(WizardEntity wizard)
    {   
        var existing = GetById(wizard.Id);
        if (existing != null)
        {

            existing.Rating = wizard.Rating;
            existing.Health = wizard.Health; 
        }
    }
}