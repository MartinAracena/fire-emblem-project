using Fire_Emblem.Model;

namespace Fire_Emblem.Battle.Attacks;

public class CounterAttack(DamageCalculator damageCalculator) : IAttack {
    private DamageCalculator _damageCalculator = new DamageCalculator();
    
    public bool CanExecute(Unit attacker, Unit defender) {
        return attacker.IsAlive() && defender.IsAlive();
    }

    public void Execute(Unit attacker, Unit defender) {
        throw new NotImplementedException();
    }
}