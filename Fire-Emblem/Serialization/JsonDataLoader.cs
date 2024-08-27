using System.Text.Json;
using Fire_Emblem.Configuration;
using Fire_Emblem.DataManagement;
using Fire_Emblem.DataTransfer;

namespace Fire_Emblem.Serialization; 

public class JsonDataLoader
{
    private UnitCatalog _unitCatalog;
    private AbilityCatalog _abilityCatalog;
    public JsonDataLoader(UnitCatalog unitCatalog, AbilityCatalog abilityCatalog) {
        _unitCatalog = unitCatalog;
        _abilityCatalog = abilityCatalog;
    }
    public void LoadUnitCatalog(string filePath) {
        string json = File.ReadAllText(filePath);
        List<UnitInfo> unitsInfo = JsonSerializer.Deserialize<List<UnitInfo>>(json);
        foreach (var unitInfo in unitsInfo) {
            _unitCatalog.AddUnit(unitInfo);
        }
    }

    public void LoadAbilityCatalog(string filePath) {
        string json = File.ReadAllText(filePath);
        List<AbilityInfo> abilitiesInfo = JsonSerializer.Deserialize<List<AbilityInfo>>(json);
        foreach (var abilityInfo in abilitiesInfo) {
            _abilityCatalog.AddAbility(abilityInfo);
        }
    }
}