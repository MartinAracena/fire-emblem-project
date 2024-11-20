using Fire_Emblem.Model;

namespace Fire_Emblem.Combat.Attacks;

public interface IAttack {
    bool CanExecute(Unit attacker, Unit defender);
    void Execute(Unit attacker, Unit defender);
}