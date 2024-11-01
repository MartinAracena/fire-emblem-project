using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class CombatSystem {
    private GameView _gameView;
    private WeaponTriangleBonus _weaponTriangleBonus;
    private DamageCalculator _damageCalculator;
    
    private List<Player> _players;
    private int _currentPlayerIndex;
    
    private bool _isRunning;
    private int _round;
    
    public CombatSystem(GameView gameView, List<Player> players) {
        _gameView = gameView;
        _weaponTriangleBonus = new WeaponTriangleBonus();
        _damageCalculator = new DamageCalculator();
        _players = players;
        _currentPlayerIndex = 0;
        _isRunning = true;
        _round = 1;
    }
    
    public void Start() {
        while (_isRunning) {
            ExecuteRound();
            RemoveDefeatedUnits();  
            CheckWinCondition();
            SwitchTurn();
            _round++;
        }
    }

    private Player GetCurrentPlayer() {
        return _players[_currentPlayerIndex];
    }

    private Player GetOpponentPlayer() {
        return _players[(_currentPlayerIndex + 1) % _players.Count];
    }

    private void ExecuteRound() {
        var attackingUnit = GetCurrentPlayer().SelectUnit(_gameView);
        var defendingUnit = GetOpponentPlayer().SelectUnit(_gameView);
        _gameView.SayThatAPlayerTurnBegins(_round, GetCurrentPlayer(), attackingUnit);
        _weaponTriangleBonus.ShowUnitAdvantage(_gameView, attackingUnit, defendingUnit);
        StartCombat(attackingUnit, defendingUnit);
        _gameView.ShowCombatResult(attackingUnit, defendingUnit);
    }
    private void StartCombat(Unit attacker , Unit defender) {
        StartOfCombatPhase(attacker, defender);
        PerformAttack(attacker, defender);
        PerformAttack(defender, attacker);
        PerformFollowUpAttack(attacker, defender);
    }
    private void StartOfCombatPhase(Unit attacker, Unit defender) {
        CombatContext context = new CombatContext(_gameView, CombatPhase.StartOfCombat, attacker, defender);
        ActivateAbilities(context, attacker, defender);
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
    
    private void CheckWinCondition() {
        var alivePlayers = _players.Where(player => player.Team.Units.Any(unit => unit.IsAlive())).ToList();
        if (alivePlayers.Count == 1) {
            _isRunning = false;
            _gameView.ShowWinner(alivePlayers.Single());
        }
    }
    private void RemoveDefeatedUnits(){
        foreach (var player in _players) {
            player.Team.Units.RemoveAll(unit => !unit.IsAlive());
        }
    }
    private void SwitchTurn() {
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }

    private void ActivateAbilities(CombatContext context, Unit attacker, Unit defender) {
        attacker.ActivateAbilities(context);
        defender.ActivateAbilities(context);
    }

    private void StartBattle() {
        ActivateAbilities();
        ExecuteAttacks();
        DeactivateAbilities();
    }

    private void ActivateAbilities() {
        
    }

    private void ExecuteAttacks() {
        
    }

    private void DeactivateAbilities() {
        
    }
}