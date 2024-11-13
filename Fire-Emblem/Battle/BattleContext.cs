using Fire_Emblem.Model;

namespace Fire_Emblem.Battle; 

public class BattleContext {
    public GameView GameView;
    public CombatPhase CurrentPhase;
    
    public AttackType AttackType;
    public Unit Attacker;
    public Unit Defender;

    public BattleContext(GameView gameView , CombatPhase currentPhase, Unit attacker, Unit defender) {
        GameView = gameView;
        CurrentPhase = currentPhase;
        Attacker = attacker;
        Defender = defender;
    }
}