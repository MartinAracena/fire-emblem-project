using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public class TeamRulesValidator {
    private readonly IEnumerable<ITeamRule> _rules;
    
    public TeamRulesValidator(IEnumerable<ITeamRule> rules) {
        _rules = rules;
    }
    
    public bool IsValid(Team team) {
        return _rules.All(rule => rule.IsValid(team));
    }
}