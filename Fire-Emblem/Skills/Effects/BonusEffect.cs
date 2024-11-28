using Fire_Emblem.Combat;
using Fire_Emblem.Model;
using Fire_Emblem.Utilities;

namespace Fire_Emblem.Skills.Effects; 

public class BonusEffect : IEffect {
    private EffectPhase _effectPhase;
    private StatType _statType;
    private int _value;
    public BonusEffect(EffectPhase effectPhase, StatType statType, int value) {
        _effectPhase = effectPhase;
        _statType = statType;
        _value = value;
    }
    public void Apply(Unit owner, BattleContext context) {
        owner.Stats.Bonuses[_effectPhase][_statType] += _value;
    }
    public void Remove(Unit owner, BattleContext context) {
        owner.Stats.Bonuses[_effectPhase][_statType] -= _value;
    }
}