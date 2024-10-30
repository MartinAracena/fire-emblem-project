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
    
    public Unit SelectUnit(GameView gameView) {
        gameView.TellAPlayerToSelectUnit(PlayerId);
        gameView.ShowUnitSelection(Team);
        return Team.Units[gameView.ReadLine()];
    }

    public bool HasUnits() {
        return Team.HasUnits();
    }

}