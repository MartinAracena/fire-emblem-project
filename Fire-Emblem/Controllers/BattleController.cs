using Fire_Emblem.Combat;
using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Controllers;

public class BattleController {
    private GameView _gameView;
    private WeaponTriangleBonus _weaponTriangleBonus;
    private DamageCalculator _damageCalculator;
    public BattleController(GameView gameView) {
        _gameView = gameView;
        _weaponTriangleBonus = new WeaponTriangleBonus();
        _damageCalculator = new DamageCalculator();
    }
    public void ResolveCombat(Unit attacker, Unit defender) {
        _weaponTriangleBonus.ShowUnitAdvantage(_gameView, attacker, defender);
        ExecuteCombat(attacker, defender);
        _gameView.ShowCombatResult(attacker, defender);
    }
    
    private void ExecuteCombat(Unit attacker , Unit defender) {
        PerformAttack(attacker, defender);
        PerformAttack(defender, attacker);
        PerformFollowUpAttack(attacker, defender);
    }
    private void PerformAttack(Unit attacker, Unit defender) {
        if(!CanPerformAttack(attacker, defender)) return;
        int damage = _damageCalculator.CalculateDamage(attacker, defender);
        defender.ReceiveDamage(damage);
        _gameView.ShowAttackInformation(attacker, defender, damage);
    }
    private bool CanPerformAttack(Unit attacker, Unit defender) {
        return attacker.IsAlive() && defender.IsAlive();
    }
    
    private void PerformFollowUpAttack(Unit attacker, Unit defender) {
        if (!CanPerformAttack(attacker, defender)) {return;}
        if (attacker.GetStat(StatType.Speed) >= defender.GetStat(StatType.Speed) + GameConfig.FollowUpMinSpdThreshold ) {
            PerformAttack(attacker, defender);
        }
        else if (defender.GetStat(StatType.Speed) >= attacker.GetStat(StatType.Speed) + GameConfig.FollowUpMinSpdThreshold ) {
            PerformAttack(defender, attacker);
        }
        else{
            _gameView.SayThatNoUnitCanDoAFollowUp();
        }
    }
}