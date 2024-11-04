using Fire_Emblem.Model;

namespace Fire_Emblem;

public class Players {
    private readonly List<Player> _players = new();

    public Players() {
        _players.Add(new Player(1));
        _players.Add(new Player(2));
    }

    public bool ArePlayersAbleToBattle() {
        foreach (var player in _players) {
            if (!player.HasUnits()) {
                return false;
            }
        }
        return true;
    }
}