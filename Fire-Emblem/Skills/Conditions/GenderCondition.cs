using Fire_Emblem.Battle;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions;

public class GenderCondition : ICondition {
    private GenderType _gender;

    public GenderCondition(GenderType gender) {
        _gender = gender;
    }
    public bool IsMet(Unit owner, BattleContext context) {
        return owner.Gender == _gender;
    }
}