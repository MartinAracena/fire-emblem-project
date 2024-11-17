using Fire_Emblem_View;
using Fire_Emblem.Configuration;
using Fire_Emblem.Controllers;
using Fire_Emblem.DataAccess;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Model;
using Fire_Emblem.Serialization;
using Fire_Emblem.TeamRules;

namespace Fire_Emblem;

public class Game {
    private GameView _gameView;
    private GameController _gameController;
    private GameSetup _gameSetup;
    
    public Game(View view, string teamsFolder) {
        _gameView = new GameView(view);
        _gameSetup = new GameSetup(_gameView, teamsFolder);
    }

    public void Play() {
        if (!_gameSetup.Initialize()) {
            return;
        };
        _gameController = new GameController(_gameView, _gameSetup.GameState);
        _gameController.StartGame();
    }
}