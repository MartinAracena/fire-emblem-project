using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions;

public class HpInRangeCondition : ICondition {
    private int _maxHp;
    private int _minHp;
    public HpInRangeCondition(int maxHp, int minHp) {
        _maxHp = maxHp;
        _minHp = minHp;
    }
    public bool IsMet(Unit owner, BattleContext context) {
        int ownerHpPercentage = owner.GetCurrentHp() / owner.GetStat(StatType.Health);
        return _maxHp >= ownerHpPercentage && _minHp <= ownerHpPercentage;
    }
}