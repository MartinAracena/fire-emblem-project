namespace Fire_Emblem.Model;

public class Player {
    public int PlayerId;
    public Team Team;

    public Player(int playerId) {
        PlayerId = playerId;
    }
    
    public void AddTeam(Team team) {
        Team = team;
    }
    public void RemoveUnit(Unit unit) {
        Team.Units.Remove(unit);
    }
    
    public bool HasUnits() {
        return Team.HasUnits();
    }

    public Unit GetUnit(int index) {
        return Team.Units[index];
    }
}