using System.Text.Json;
using Fire_Emblem.Configuration;
using Fire_Emblem.DataTransfer;

namespace Fire_Emblem.Serialization; 

public class JsonDataLoader {
    public void LoadUnitCatalog() {
        string json = File.ReadAllText(GameConfig.DefaultCharacterFilePath);
        List<UnitInfo> unitsInfo = JsonSerializer.Deserialize<List<UnitInfo>>(json);
    }

    public void LoadAbilityCatalog() {
        string json = File.ReadAllText(GameConfig.DefaultAbilityFilePath);
        List<AbilityInfo> abilitiesInfo = JsonSerializer.Deserialize<List<AbilityInfo>>(json);
    }
}