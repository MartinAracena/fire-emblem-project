using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Effects; 

public class StatPenaltyEffect : IEffect {
    private Stats _stats;
    public StatPenaltyEffect(StatType statType, int value) {
        _stats = new Stats(statType, value);
    }
    public void Apply(Unit owner, CombatContext context) {

    }

    public void Remove(Unit owner, CombatContext context) {
    }
}