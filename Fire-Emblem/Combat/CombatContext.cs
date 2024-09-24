using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class CombatContext {
    public GameView GameView;
    public CombatPhase CurrentPhase;
    public Unit Attacker;
    public Unit Defender;

    public CombatContext(GameView gameView , CombatPhase currentPhase, Unit attacker, Unit defender) {
        GameView = gameView;
        CurrentPhase = currentPhase;
        Attacker = attacker;
        Defender = defender;
    }
}