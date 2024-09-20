using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class CombatSystem {
    private GameView _gameView;
    private WeaponTriangleBonus _weaponTriangleBonus;
    private DamageCalculator _damageCalculator;
    
    private List<Player> _players;
    
    private Player _player1;
    private Player _player2;
    
    private Player _winner;
    private Unit _firstPlayerUnit;
    private Unit _secondPlayerUnit;
    private Unit _currentAttacker;
    private Unit _currentDefender;
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

    public void Start() {
        while (_isRunning) {
            StartTurn();
            ShowUnitAdvantage();
            ExecuteCombat();
            ShowCombatResult();
            CheckWinCondition();
            SwitchTurn();
            _round++;
        }

        ShowWinner();
    }

    private void StartTurn() {
        _gameView.TellAPlayerToSelectUnit(_players.First().PlayerId);
        _gameView.ShowUnitSelection(_players.First().Team);
        _currentAttacker = _firstPlayerUnit = _players.First().Team.Units[_gameView.ReadLine()];
        
        
        _gameView.TellAPlayerToSelectUnit(_players.Last().PlayerId);
        _gameView.ShowUnitSelection(_players.Last().Team);
        _currentDefender = _secondPlayerUnit = _players.Last().Team.Units[_gameView.ReadLine()];
        
        _gameView.SayThatAPlayerTurnBegins(_round, _players.First(), _currentAttacker);
    }
    
    private void ShowUnitAdvantage() {
        double advantage = _weaponTriangleBonus.CalculateBonus(_currentAttacker.Weapon, _currentDefender.Weapon);
        if (advantage == GameConfig.WeaponTriangleBonus) {
            _gameView.SayThatAUnitHasWeaponAdvantage(_currentAttacker, _currentDefender);
        }
        else if (advantage == GameConfig.WeaponTrianglePenalty) {
            _gameView.SayThatAUnitHasWeaponAdvantage(_currentDefender, _currentAttacker);
        }
        else {
            _gameView.SayThatThereIsNoWeaponAdvantage();
        }
    }

    private void ExecuteCombat() {
        ExecuteAttack();
        if (CheckWinCondition() && AreBothUnitsAlive()) {
            ExecuteCounterAttack();
        }

        if (CheckWinCondition() && AreBothUnitsAlive()) {
            if (CanPerformFollowUp()) {
                ExecuteFollowUp();
                RemoveDefeatedUnits();
            }
        }
        RemoveDefeatedUnits();
    }

    private void ExecuteAttack() {
        int damage = _damageCalculator.CalculateDamage(_currentAttacker, _currentDefender);
        _currentDefender.ReceiveDamage(damage);
        _gameView.ShowAttackInformation(_currentAttacker, _currentDefender, damage);
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

    private void ExecuteCounterAttack() {
        int damage = _damageCalculator.CalculateDamage(_currentDefender, _currentAttacker);
        _currentAttacker.ReceiveDamage(damage);
        _gameView.ShowAttackInformation(_currentDefender, _currentAttacker, damage);
    }
    
    private bool CanPerformFollowUp() {
        int speedDifference = _currentAttacker.Spd - _currentDefender.Spd;

        if (speedDifference is >= 5 or <= -5) {
            if (speedDifference <= -5) {
                SwitchAttacker();
            }
            return true;
        }
        _gameView.SayThatNoUnitCanDoAFollowUp();
        return false;
    }
    
    private void ExecuteFollowUp() {
        int damage = _damageCalculator.CalculateDamage(_currentAttacker, _currentDefender);
        _currentDefender.ReceiveDamage(damage);
        _gameView.ShowAttackInformation(_currentAttacker, _currentDefender, damage);
    }

    private bool AreBothUnitsAlive() {
        return _currentAttacker.IsAlive() && _currentDefender.IsAlive();
    }
    
    private void RemoveDefeatedUnits(){
        foreach (var player in _players){
            var unitsToRemove = player.Team.Units.Where(unit => unit.currentHp == 0).ToList();
            foreach (var unit in unitsToRemove){
                player.RemoveUnit(unit);
            }
        }
    }

    private void ShowCombatResult() {
        _gameView.ShowCombatResult(_firstPlayerUnit, _secondPlayerUnit);
    }

    private void SwitchAttacker() {
        (_currentAttacker, _currentDefender) = (_currentDefender, _currentAttacker);
    }

    private void SwitchTurn() {
        _players.Reverse();
    }

    private void ShowWinner() {
        _gameView.ShowWinner(_winner);
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
    
    private bool CanPerformCombat(Unit attacker, Unit defender) {
        return attacker.IsAlive() && defender.IsAlive();
    }

    private void PerformAttack(Unit attacker, Unit defender) {
        int damage = _damageCalculator.CalculateDamage(attacker, defender);
        defender.ReceiveDamage(damage);
        _gameView.ShowAttackInformation(attacker, defender, damage);
    }
    
    private void PerformFollowUpAttack(Unit attacker, Unit defender) {
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
}