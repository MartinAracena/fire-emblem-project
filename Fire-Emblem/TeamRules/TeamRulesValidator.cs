using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public class TeamRulesValidator(IEnumerable<ITeamRule> rules) {
    public bool IsValid(Team team) {
        return rules.All(rule => rule.IsValid(team));
    }
}