using Fire_Emblem.Model;

namespace Fire_Emblem.Combat.CombatLog; 

public class PhaseLog {
    public Dictionary<StatType, StatChangeLog> StatLogs { get; set; } = new Dictionary<StatType, StatChangeLog>();
}