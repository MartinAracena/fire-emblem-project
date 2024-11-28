using Fire_Emblem.Model;
using Fire_Emblem.Utilities;

namespace Fire_Emblem.Combat; 

public class BattleContext {
    public GameView GameView;
    
    public Unit Attacker;
    public Unit Defender;

    public BattleContext(GameView gameView, Unit attacker, Unit defender) {
        GameView = gameView;
        Attacker = attacker;
        Defender = defender;
    }
}