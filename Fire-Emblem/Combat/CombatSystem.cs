using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class CombatSystem {
    private GameView _gameView;
    private WeaponTriangleBonus _weaponTriangleBonus;
    private DamageCalculator _damageCalculator;
    
    private List<Player> _players;
    
    private Player _winner;
    private bool _isRunning;
    private int _round;
    
    public CombatSystem(GameView gameView, List<Player> players) {
        _gameView = gameView;
        _weaponTriangleBonus = new WeaponTriangleBonus();
        _damageCalculator = new DamageCalculator();
        _players = players;
        _isRunning = true;
        _round = 1;
    }
    
    public void StartCombat() {
        while (_isRunning) {
            StartRound(_players.First(), _players.Last());
            RemoveDefeatedUnits();
            SwitchTurn();
            _round++;
            
            CheckWinCondition();
        }
        ShowWinner();
    }

    private void StartRound(Player attacker, Player defender) {
        var attackingUnit = attacker.SelectUnit(_gameView);
        var defendingUnit = defender.SelectUnit(_gameView);
        _gameView.SayThatAPlayerTurnBegins(_round, attacker, attackingUnit);
        _weaponTriangleBonus.ShowUnitAdvantage(_gameView, attackingUnit, defendingUnit);
        PerformAttack(attackingUnit, defendingUnit);
        PerformAttack(defendingUnit, attackingUnit);
        PerformFollowUpAttack(attackingUnit, defendingUnit);
        _gameView.ShowCombatResult(attackingUnit, defendingUnit);
    }

    private void StartCombat(Unit attacker , Unit defender) {
        PerformAttack(attacker, defender);
        PerformAttack(defender, attacker);
        PerformFollowUpAttack(attacker, defender);
    }
    
    private void PerformAttack(Unit attacker, Unit defender) {
        if(!CanPerformAttack(attacker)) return;
        int damage = _damageCalculator.CalculateDamage(attacker, defender);
        defender.ReceiveDamage(damage);
        _gameView.ShowAttackInformation(attacker, defender, damage);
    }
    private bool CanPerformAttack(Unit attacker) {
        return attacker.IsAlive();
    }
    
    private void PerformFollowUpAttack(Unit attacker, Unit defender) {
        if (!attacker.IsAlive() || !defender.IsAlive()) {return;}
        if (attacker.Spd >= defender.Spd + GameConfig.FollowUpMinSpdThreshold ) {
            PerformAttack(attacker, defender);
        }
        else if (defender.Spd >= attacker.Spd + GameConfig.FollowUpMinSpdThreshold ) {
            PerformAttack(defender, attacker);
        }
        else{
            _gameView.SayThatNoUnitCanDoAFollowUp();
        }
    }
    
    private bool CheckWinCondition() {
        var alivePlayers = _players.Where(player => player.Team.Units.Any(unit => unit.currentHp > 0)).ToList();
        if (alivePlayers.Count == 1) {
            _isRunning = false;
            _winner = alivePlayers.Single();
            return false;
        }

        return true;
    }
    private void RemoveDefeatedUnits(){
        foreach (var player in _players){
            var unitsToRemove = player.Team.Units.Where(unit => unit.currentHp == 0).ToList();
            foreach (var unit in unitsToRemove){
                player.RemoveUnit(unit);
            }
        }
    }
    private void SwitchTurn() {
        _players.Reverse();
    }

    private void ShowWinner() {
        _gameView.ShowWinner(_winner);
    }
}