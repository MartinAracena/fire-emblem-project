namespace Fire_Emblem.Model;

public class Stats {
    private Dictionary<StatType, int> _stats;

    public Stats(int health, int attack, int speed, int defense, int resistance) {
        _stats = new Dictionary<StatType, int> {
            { StatType.Health, health },
            { StatType.Attack, attack },
            { StatType.Speed, speed },
            { StatType.Defense, defense },
            { StatType.Resistance, resistance },
            
        };
    }
    public int GetStat(StatType statType) {
        return _stats[statType];
    }
}