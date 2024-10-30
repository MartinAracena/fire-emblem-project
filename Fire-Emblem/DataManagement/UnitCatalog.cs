using Fire_Emblem.DataTransfer;
using Fire_Emblem.Model;

namespace Fire_Emblem.DataManagement; 

public class UnitCatalog {
    private Dictionary<string, UnitInfo> _unitInfos = new Dictionary<string, UnitInfo>();

    public void AddUnit(UnitInfo unitInfo) {
        _unitInfos.Add(unitInfo.Name, unitInfo);
    }

    public Unit GetUnit(string unitName) {
        UnitInfo unitInfo = _unitInfos[unitName];
        
        WeaponType weapon = Enum.Parse<WeaponType>(unitInfo.Weapon, true);
        GenderType gender = Enum.Parse<GenderType>(unitInfo.Gender, true);
        
        Stats stats = GetStatsFromUnitInfo(unitInfo);
        
        return new Unit(
            unitInfo.Name,
            weapon,
            gender,
            unitInfo.DeathQuote,
            stats
        );
    }
    private Stats GetStatsFromUnitInfo(UnitInfo unitInfo) {
        return new Stats(
            int.Parse(unitInfo.HP),
            int.Parse(unitInfo.Atk),
            int.Parse(unitInfo.Spd),
            int.Parse(unitInfo.Def),
            int.Parse(unitInfo.Res)
        );
    }
}