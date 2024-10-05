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
        
        int hp = int.Parse(unitInfo.HP);
        int atk = int.Parse(unitInfo.Atk);
        int spd = int.Parse(unitInfo.Spd);
        int def = int.Parse(unitInfo.Def);
        int res = int.Parse(unitInfo.Res);
        Stats stats = new Stats(hp, atk, spd, def, res);
        
        return new Unit(
            unitInfo.Name,
            weapon,
            gender,
            unitInfo.DeathQuote,
            stats
        );
    }
}