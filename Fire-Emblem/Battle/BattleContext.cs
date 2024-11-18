using Fire_Emblem.Model;

namespace Fire_Emblem.Battle; 

public class BattleContext {
    public GameView GameView;
    
    public AttackType AttackType;
    public Unit Attacker;
    public Unit Defender;

    public BattleContext(GameView gameView, Unit attacker, Unit defender) {
        GameView = gameView;
        Attacker = attacker;
        Defender = defender;
    }
}