namespace ConsoleApp1;
using System.Collections.Generic;
using System.Linq;

public static class WizardMapper
{
    public static WizardDTO ToDto(WizardEntity entity, List<SpellEntity> spells)
    {
        return new WizardDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            House = entity.House,
            Rating = entity.Rating,
            WizardType = entity.WizardType,
            SpellNames = spells.Select(s => s.Name).ToList()
        };
    }
}