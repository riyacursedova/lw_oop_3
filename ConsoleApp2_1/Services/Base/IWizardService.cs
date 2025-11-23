namespace ConsoleApp1;
using System.Collections.Generic;

public interface IWizardService
{
    WizardDTO GetWizardDetails(int id);
    List<WizardDTO> GetAllWizards();
}