using Fire_Emblem.Model;

namespace Fire_Emblem.Combat.CombatLog; 

public class CombatLog {
    public Dictionary<Unit, UnitLog> UnitLogs { get; set; } = new Dictionary<Unit, UnitLog>();

    public CombatLog(Unit attacker, Unit defender) {
        UnitLogs[attacker] = new UnitLog();
        UnitLogs[defender] = new UnitLog();
    }
}