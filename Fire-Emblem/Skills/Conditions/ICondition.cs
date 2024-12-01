using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions;

public interface ICondition {
    bool IsMet(Unit self, Unit opponent, BattleContext context);
}