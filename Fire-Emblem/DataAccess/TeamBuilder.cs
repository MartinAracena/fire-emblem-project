using Fire_Emblem.DataManagement;
using Fire_Emblem.Model;

namespace Fire_Emblem.DataAccess; 

public class TeamBuilder {
    private readonly UnitCatalog _unitCatalog;
    private readonly AbilityCatalog _abilityCatalog;

    public TeamBuilder(UnitCatalog unitCatalog, AbilityCatalog abilityCatalog) {
        _unitCatalog = unitCatalog;
        _abilityCatalog = abilityCatalog;
    }

    public void BuildTeam(List<Tuple<string, List<string>>> unitData) {
        var team = new Team();
        
        foreach (var unitInfo in unitData) {
            var unit = CreateUnit(unitInfo.Item1, unitInfo.Item2);
            team.AddUnit(unit);
        }
    }

    public Unit CreateUnit(string unitName, List<string> abilities) {
        var unit = _unitCatalog.GetUnit(unitName);

        foreach (var abilityName in abilities) {
            var ability = _abilityCatalog.GetAbility(abilityName);
            unit.AddAbility(ability);
        }

        return unit;
    }

}