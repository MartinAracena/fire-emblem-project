using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public class MaximumAbilitiesPerUnitRule : ITeamRule {
    public bool IsValid(Team team) {
        return team.Units.All(unit => unit.Skills.Count <= GameConfig.MaxAbilitiesPerUnit);
    }
}