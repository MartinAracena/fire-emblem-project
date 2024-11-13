using Fire_Emblem.Battle;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Effects; 

public class StatBonusEffect : IEffect {
    private StatType _statType;
    private int _value;
    public StatBonusEffect(StatType statType, int value) {
        _statType = statType;
        _value = value;
    }
    public void Apply(Unit owner, BattleContext context) {
    }
    public void Remove(Unit owner, BattleContext context) {
    }
}