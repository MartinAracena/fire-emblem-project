using Fire_Emblem.Combat;
using Fire_Emblem.Model;
using Fire_Emblem.Utilities;

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