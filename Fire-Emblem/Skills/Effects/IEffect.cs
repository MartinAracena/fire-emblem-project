using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Effects;

public interface IEffect {
    void Apply(Unit self, Unit opponent, BattleContext context);
    void Remove(Unit self, Unit opponent, BattleContext context);
}