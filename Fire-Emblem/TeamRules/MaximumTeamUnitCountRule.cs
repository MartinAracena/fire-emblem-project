using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public class MaximumTeamUnitCountRule : ITeamRule {
    public bool IsValid(Team team) {
        return team.Units.Count <= GameConfig.MaxTeamUnits;
    }
}