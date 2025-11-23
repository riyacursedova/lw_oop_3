namespace ConsoleApp1;
using System.Collections.Generic;
using System.Linq;

public class WizardService : IWizardService
{
    private readonly IWizardRepository _wizardRepo;
    private readonly ISpellRepository _spellRepo;

    public WizardService(IWizardRepository wizardRepo, ISpellRepository spellRepo)
    {
        _wizardRepo = wizardRepo;
        _spellRepo = spellRepo;
    }

    public List<WizardDTO> GetAllWizards()
    {
        var dtos = new List<WizardDTO>();
        var entities = _wizardRepo.GetAll();
        foreach (var entity in entities)
        {
            dtos.Add(GetWizardDetails(entity.Id));
        }
        return dtos;
    }

    public WizardDTO GetWizardDetails(int id)
    {
        var wizardEntity = _wizardRepo.GetById(id);
        if (wizardEntity == null) return null;

        var spells = _spellRepo.GetSpellsForWizard(id);
        return WizardMapper.ToDto(wizardEntity, spells);
    }
}