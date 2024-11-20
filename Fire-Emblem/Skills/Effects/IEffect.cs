using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Effects;

public interface IEffect {
    void Apply(Unit owner, BattleContext context);
    void Remove(Unit owner, BattleContext context);
}