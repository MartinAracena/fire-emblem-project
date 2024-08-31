using Fire_Emblem.DataAccess;

namespace Fire_Emblem.Model;

public class Player {
    public int PlayerId;
    public Team Units = new Team();
    
    public Player(int playerId) {
        PlayerId = playerId;
    }
}