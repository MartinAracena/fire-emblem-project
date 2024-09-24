namespace Fire_Emblem.Combat.CombatLog; 

public class UnitLog {
    public Dictionary<CombatPhase, PhaseLog> PhaseLogs { get; set; } = new Dictionary<CombatPhase, PhaseLog>();
}