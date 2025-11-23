namespace ConsoleApp1;

using System.Collections.Generic;
using System.Linq;

public class SpellRepository : ISpellRepository
{
    private readonly HogwartsDbContext _context;

    public SpellRepository(HogwartsDbContext context)
    {
        _context = context;
    }

    public SpellEntity GetById(int id)
    {
        return _context.Spells.FirstOrDefault(s => s.Id == id);
    }
    
    public List<SpellEntity> GetSpellsForWizard(int wizardId)
    {

        var spellIds = _context.WizardSpells
            .Where(ws => ws.WizardId == wizardId)
            .Select(ws => ws.SpellId);
        
        return _context.Spells
            .Where(s => spellIds.Contains(s.Id))
            .ToList();
    }
}