using Fire_Emblem.Combat;
using Fire_Emblem.Model;
using Fire_Emblem.Utilities;

namespace Fire_Emblem.Skills.Effects; 

public class PenaltyEffect : IEffect {
    private StatType _statType;
    private int _value;
    public PenaltyEffect(StatType statType, int value) {
        _statType = statType;
        _value = value;
    }
    public void Apply(Unit owner, BattleContext context) {

    }

    public void Remove(Unit owner, BattleContext context) {
    }
}