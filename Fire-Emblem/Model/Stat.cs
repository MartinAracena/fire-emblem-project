namespace Fire_Emblem.Model;

public class Stat {
    private StatType _statType;
    private int _value;
    
    public Stat(StatType statType, int value) {
        _statType = statType;
        _value = value;
    }
}