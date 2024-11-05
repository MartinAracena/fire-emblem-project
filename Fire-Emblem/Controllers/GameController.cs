using Fire_Emblem.Model;

namespace Fire_Emblem.Controllers;

public class GameController {
    private GameView _gameView;
    private Player _playerOne;
    private Player _playerTwo;
    private BattleController _battleController;
    private int _round;
    
    private Player _currentPlayer;
    private Player _opponentPlayer;

    public GameController(GameView gameView, GameState gameState) {
        _gameView = gameView;
        _playerOne = gameState.PlayerOne;
        _playerTwo = gameState.PlayerTwo;
        _round = 1;
        _battleController = new BattleController(gameView);
        _currentPlayer = _playerOne;
        _opponentPlayer = _playerTwo;
    }

    public void StartGame() {
        while (!IsGameOver()) {
            ExecuteTurn();
            RemoveDefeatedUnits();
            SwitchTurns();
            _round++;
        }
        AnnounceWinner();
    }

    private void ExecuteTurn() {
        Unit attacker = _currentPlayer.SelectUnit(_gameView);
        Unit defender = _opponentPlayer.SelectUnit(_gameView);
        _gameView.SayThatAPlayerTurnBegins(_round, _currentPlayer, attacker);
        _battleController.ResolveCombat(attacker, defender);
    }
    private void RemoveDefeatedUnits(){
        _playerOne.Team.Units.RemoveAll(unit => !unit.IsAlive());
        _playerTwo.Team.Units.RemoveAll(unit => !unit.IsAlive());
    }

    private void SwitchTurns() {
        (_currentPlayer, _opponentPlayer) = (_opponentPlayer, _currentPlayer);
    }

    private bool IsGameOver() {
        return !_playerOne.HasUnits() || !_playerTwo.HasUnits();
    }

    private void AnnounceWinner() {
        if (_playerOne.HasUnits()) {
            _gameView.ShowWinner(_playerOne);
        } else if (_playerTwo.HasUnits()) {
            _gameView.ShowWinner(_playerTwo);
        }
    }
}