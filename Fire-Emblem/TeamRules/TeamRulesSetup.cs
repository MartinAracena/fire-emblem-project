namespace Fire_Emblem.TeamRules;

public class TeamRulesSetup {
    public TeamRulesValidator LoadRules() {
        var rules = new List<ITeamRule> {
            new MinimumTeamUnitCountRule(),
            new MaximumTeamUnitCountRule(),
            new MaximumDuplicateUnitCountRule(),
            new MaximumAbilitiesPerUnitRule(),
            new MaximumDuplicateAbilityCountPerUnitRule()
        };
        return new TeamRulesValidator(rules);
    }
}