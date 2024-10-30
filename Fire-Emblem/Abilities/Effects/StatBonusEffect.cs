using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Effects; 

public class StatBonusEffect : IEffect {
    private StatType _statType;
    private int _value;
    public StatBonusEffect(StatType statType, int value) {
        _statType = statType;
        _value = value;
    }
    public void Apply(Unit owner, CombatContext context) {
    }
    public void Remove(Unit owner, CombatContext context) {
    }
}