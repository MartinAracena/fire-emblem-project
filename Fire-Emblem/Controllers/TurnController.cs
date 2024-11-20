using Fire_Emblem.Model;

namespace Fire_Emblem.Controllers;

public class TurnController {
    private GameView _gameView;
    private CombatController _combatController;

    public TurnController(GameView gameView, CombatController combatController) {
        _gameView = gameView;
        _combatController = combatController;
    }

    public void StartTurn(Player currentPlayer, Player opponentPlayer, int round) {
        Unit attacker = SelectUnitForPlayer(currentPlayer);
        Unit defender = SelectUnitForPlayer(opponentPlayer);
        _gameView.SayThatAPlayerTurnBegins(round, currentPlayer, attacker);
        _combatController.StartCombat(attacker, defender);
    }

    private Unit SelectUnitForPlayer(Player player) {
        _gameView.TellAPlayerToSelectUnit(player);
        _gameView.ShowUnitSelection(player.Team);
        return player.GetUnit(_gameView.ReadLine());
    }
}