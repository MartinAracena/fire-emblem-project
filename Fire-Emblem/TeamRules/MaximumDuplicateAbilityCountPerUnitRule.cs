using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public class MaximumDuplicateAbilityCountPerUnitRule : ITeamRule {
    public bool IsValid(Team team) {
        foreach (var unit in team.Units) {
            var abilityCounts = unit.Abilities.GroupBy(ability => ability.Name).Select(abilityGroup => abilityGroup.Count());

            if (abilityCounts.Any(count => count > GameConfig.MaxDuplicateAbilitiesPerUnit)) {
                return false;
            }
        }
        return true;
    }
}