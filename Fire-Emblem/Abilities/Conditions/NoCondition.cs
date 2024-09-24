using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Conditions;

public class NoCondition : ICondition {
    public bool IsApplicable(Unit owner, CombatContext context) {
        return true;
    }
}