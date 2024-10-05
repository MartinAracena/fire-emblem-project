using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Effects; 

public class StatBonusEffect : IEffect {
    private Stat _stat;
    public StatBonusEffect(StatType statType, int value) {
        _stat = new Stat(statType, value);
    }
    public void Apply(Unit owner, CombatContext context) {
    }
    public void Remove(Unit owner, CombatContext context) {
    }
}