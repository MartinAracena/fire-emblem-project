using Fire_Emblem.Battle;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions;

public class NoCondition : ICondition {
    public bool IsMet(Unit owner, BattleContext context) {
        return true;
    }
}