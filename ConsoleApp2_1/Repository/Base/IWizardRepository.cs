namespace ConsoleApp1;

public interface IWizardRepository // Description methods
{
    WizardEntity GetById(int id); 
    List<WizardEntity> GetAll(); 
    void Update(WizardEntity wizard);

}