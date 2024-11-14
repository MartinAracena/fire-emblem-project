using Fire_Emblem.Model;

namespace Fire_Emblem.Validation.Rules;

public interface ITeamValidationRule {
    bool IsValid(Team team);
}