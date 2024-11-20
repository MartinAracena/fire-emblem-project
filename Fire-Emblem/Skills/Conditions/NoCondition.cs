using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions;

public class NoCondition : ICondition {
    public bool IsMet(Unit owner, BattleContext context) {
        return true;
    }
}