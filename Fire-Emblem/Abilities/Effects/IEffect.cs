using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Effects;

public interface IEffect {
    void Apply(Unit owner, CombatContext context);
    void Remove(Unit owner, CombatContext context);
}