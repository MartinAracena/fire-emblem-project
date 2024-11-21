using Fire_Emblem.Utilities;

namespace Fire_Emblem.Model;

public class Stats {
    public Dictionary<StatType, int> BaseStats = new Dictionary<StatType, int>();
    public Dictionary<ModifierType, Dictionary<AttackPhase, Dictionary<StatType, int>>> Modifiers = new();
}