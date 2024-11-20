using Fire_Emblem.Controllers;
using Fire_Emblem.Model;

namespace Fire_Emblem.Combat;

public class CombatSystem {
    private GameView _gameView;
    private CombatController _combatController;
    private TurnController _turnController;
    private int _round;
    
    private Player _currentPlayer;
    private Player _opponentPlayer;

    public CombatSystem(GameView gameView, GameState gameState) {
        _gameView = gameView;
        _currentPlayer = gameState.PlayerOne;
        _opponentPlayer = gameState.PlayerTwo;
        _round = 1;
        _combatController = new CombatController(gameView, new WeaponTriangleBonus(), new DamageCalculator());
        _turnController = new TurnController(gameView, _combatController);
    }

    public void StartGame() {
        while (!IsGameOver()) {
            ExecuteTurn();
            SwitchTurns();
            _round++;
        }
        AnnounceWinner();
    }

    private void ExecuteTurn() {
        _turnController.StartTurn(_currentPlayer, _opponentPlayer, _round);
    }

    private void SwitchTurns() {
        (_currentPlayer, _opponentPlayer) = (_opponentPlayer, _currentPlayer);
    }

    private bool IsGameOver() {
        return !_currentPlayer.HasUnits() || !_opponentPlayer.HasUnits();
    }

    private void AnnounceWinner() {
        if (_currentPlayer.HasUnits()) {
            _gameView.ShowWinner(_currentPlayer);
        } else if (_opponentPlayer.HasUnits()) {
            _gameView.ShowWinner(_opponentPlayer);
        }
    }
}