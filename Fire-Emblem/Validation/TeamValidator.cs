using System.Net.Sockets;
using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Validation;

public class TeamValidator {
    public bool IsValid(Team team) {
        return ValidateMinTeamUnits(team) &&
               ValidateMaxTeamUnits(team) &&
               ValidateMaxDuplicateUnits(team) &&
               ValidateMaxAbilitiesPerUnit(team) &&
               ValidateMaxDuplicateAbilitiesPerUnit(team);
    }

    private bool ValidateMinTeamUnits(Team team) {
        return team.Units.Count >= GameConfig.MinTeamUnits;
    }
    
    private bool ValidateMaxTeamUnits(Team team) {
        return team.Units.Count <= GameConfig.MaxTeamUnits;
    }

    private bool ValidateMaxDuplicateUnits(Team team) {
        var unitCounts = team.Units.GroupBy(unit => unit.Name).Select(unitGroup => unitGroup.Count());
        
        return unitCounts.All(count => count <= GameConfig.MaxDuplicateUnits);
    }

    private bool ValidateMaxAbilitiesPerUnit(Team team) {
        return team.Units.All(unit => unit.Abilities.Count <= GameConfig.MaxAbilitiesPerUnit);
    }

    private bool ValidateMaxDuplicateAbilitiesPerUnit(Team team) {
        foreach (var unit in team.Units) {
            var abilityCounts = unit.Abilities.GroupBy(ability => ability.Name).Select(abilityGroup => abilityGroup.Count());

            if (abilityCounts.Any(count => count > GameConfig.MaxDuplicateAbilitiesPerUnit)) {
                return false;
            }
        }
        return true;
    }
}