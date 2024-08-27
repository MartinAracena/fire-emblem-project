namespace Fire_Emblem.Abilities.Conditions;

public class NoCondition : ICondition {
    public bool IsApplicable() {
        return true;
    }
}