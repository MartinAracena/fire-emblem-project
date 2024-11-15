using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public class MaximumDuplicateUnitCountRule : ITeamRule { 
    public bool IsValid(Team team) {
        var unitCounts = team.Units.GroupBy(unit => unit.Name).Select(unitGroup => unitGroup.Count());
        
        return unitCounts.All(count => count <= GameConfig.MaxDuplicateUnits);
    }
}