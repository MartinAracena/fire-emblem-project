using Fire_Emblem.Model;

namespace Fire_Emblem.Controllers;

public class TurnController {
    private GameView _gameView;
    private CombatController _combatController;

    public TurnController(GameView gameView, CombatController combatController) {
        _gameView = gameView;
        _combatController = combatController;
    }

    public void ExecuteTurn(Player currentPlayer, Player opponentPlayer, int round) {
        Unit attacker = currentPlayer.SelectUnit(_gameView);
        Unit defender = opponentPlayer.SelectUnit(_gameView);
        _gameView.SayThatAPlayerTurnBegins(round, currentPlayer, attacker);
        _combatController.ResolveCombat(attacker, defender);
    }
}