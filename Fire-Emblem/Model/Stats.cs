using Fire_Emblem.Utilities;

namespace Fire_Emblem.Model;

public class Stats {
    public Dictionary<StatType, int> BaseStats { get; set; } = new();
    public Dictionary<EffectPhase, Dictionary<StatType, int>> Bonuses { get; set; } = new();
    public Dictionary<EffectPhase, Dictionary<StatType, int>> Penalties { get; set; } = new();
    public HashSet<StatType> NeutralizedBonuses { get; set; } = new();
    public HashSet<StatType> NeutralizedPenalties { get; set; } = new();

    public Stats(int hp, int atk, int spd, int def , int res) {
        InitializeBaseStats(hp, atk, spd, def, res);
        InitializeBonuses();
        InitializePenalties();
    }

    private void InitializeBaseStats(int hp, int atk, int spd, int def, int res) {
        BaseStats[StatType.Hp] = hp;
        BaseStats[StatType.Atk] = atk;
        BaseStats[StatType.Spd] = spd;
        BaseStats[StatType.Def] = def;
        BaseStats[StatType.Res] = res;
    }

    private void InitializeBonuses() {
        foreach (EffectPhase phase in Enum.GetValues(typeof(EffectPhase))) {
            Bonuses[phase] = new Dictionary<StatType, int>();
            foreach (StatType stat in Enum.GetValues(typeof(StatType))) {
                Bonuses[phase][stat] = 0;
            }
        }
    }
    
    private void InitializePenalties() {
        foreach (EffectPhase phase in Enum.GetValues(typeof(EffectPhase))) {
            Penalties[phase] = new Dictionary<StatType, int>();
            foreach (StatType stat in Enum.GetValues(typeof(StatType))) {
                Penalties[phase][stat] = 0;
            }
        }
    }
}