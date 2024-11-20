using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Combat.Attacks;

public class FollowUpAttack(DamageCalculator damageCalculator) : IAttack {
    private DamageCalculator _damageCalculator = damageCalculator;
    
    public bool CanExecute(Unit attacker, Unit defender) {
        return AreBothUnitsAlive(attacker, defender) && HasSufficientSpeedDifference(attacker, defender);
    }

    private bool AreBothUnitsAlive(Unit attacker, Unit defender) {
        return attacker.IsAlive() && defender.IsAlive();
    }
    
    private bool HasSufficientSpeedDifference(Unit attacker, Unit defender) {
        int speedDifference = Math.Abs(attacker.GetStat(StatType.Speed) - defender.GetStat(StatType.Speed));
        return speedDifference >= GameConfig.FollowUpSpeedDifferenceRequirement;
    }

    public void Execute(Unit attacker, Unit defender) {
        Unit currentAttacker = DetermineAttacker(attacker, defender);
        Unit currentDefender = currentAttacker == attacker ? defender : attacker;
        ApplyDamage(defender, CalculateDamage(currentAttacker, currentDefender));
    }
    
    private Unit DetermineAttacker(Unit attacker, Unit defender) {
        if (attacker.GetStat(StatType.Speed) - defender.GetStat(StatType.Speed) >=
            GameConfig.FollowUpSpeedDifferenceRequirement)
            return attacker;
        return defender;
    }

    private int CalculateDamage(Unit attacker, Unit defender) {
        return _damageCalculator.CalculateDamage(attacker, defender);
    }

    private void ApplyDamage(Unit defender, int damage) {
        defender.ReceiveDamage(damage);
    }
}