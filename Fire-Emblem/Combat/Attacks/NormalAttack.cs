using Fire_Emblem.Model;

namespace Fire_Emblem.Combat.Attacks;

public class NormalAttack(DamageCalculator damageCalculator) : IAttack {
    private DamageCalculator _damageCalculator = damageCalculator;

    public bool CanExecute(Unit attacker, Unit defender) {
        return attacker.IsAlive() && defender.IsAlive();
    }

    public void Execute(Unit attacker, Unit defender) {
        throw new NotImplementedException();
    }
}