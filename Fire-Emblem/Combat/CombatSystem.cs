using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class CombatSystem {
    private List<Player> _players;
    private DamageCalculator _damageCalculator;
    
    public CombatSystem(List<Player> players) {
        _damageCalculator = new DamageCalculator();
        _players = players;
    }

    public void StartCombat() {
        throw new NotImplementedException();
    }
    
}