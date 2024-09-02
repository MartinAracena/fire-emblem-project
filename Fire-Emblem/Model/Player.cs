using Fire_Emblem.DataAccess;

namespace Fire_Emblem.Model;

public class Player {
    public int PlayerId;
    public Team Team;
    public void AddTeam(Team team) {
        Team = team;
    }
}