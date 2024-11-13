using Fire_Emblem.Battle;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions;

public interface ICondition {
    bool IsMet(Unit owner, BattleContext context);
}