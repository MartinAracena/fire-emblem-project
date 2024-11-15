using Fire_Emblem.Model;

namespace Fire_Emblem.TeamRules;

public interface ITeamRule {
    bool IsValid(Team team);
}