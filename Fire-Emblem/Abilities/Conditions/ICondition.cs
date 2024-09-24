using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Conditions;

public interface ICondition {
    bool IsApplicable(Unit owner, CombatContext context);
}