using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class CombatContext {
    public CombatPhase CombatPhase { get; set; }
    public Unit attacker { get; set; }
    public Unit defender { get; set; }
    public int damage { get; set; }
}