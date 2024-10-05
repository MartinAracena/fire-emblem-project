namespace Fire_Emblem.Model;

public class Stats {
    private Dictionary<StatType, int> _statsDictionary = new Dictionary<StatType, int>();

    public Stats(int hp = 0, int atk = 0, int spd = 0, int def = 0, int res = 0) {
        _statsDictionary[StatType.HP] = hp;
        _statsDictionary[StatType.Atk] = atk;
        _statsDictionary[StatType.Spd] = spd;
        _statsDictionary[StatType.Def] = def;
        _statsDictionary[StatType.Res] = res;
    }
    public Stats(StatType statType, int value) {
        _statsDictionary[statType] = value;
    }

    public void AddStat(Stats stats) {
        foreach (var stat in stats._statsDictionary) {
            _statsDictionary[stat.Key] += stat.Value;
        }
    }
    public int GetStat(StatType statType) {
        return _statsDictionary[statType];
    }
}