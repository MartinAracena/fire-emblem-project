using Fire_Emblem.Configuration;
using Fire_Emblem.DataAccess;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Model;
using Fire_Emblem.Serialization;
using Fire_Emblem.TeamRules;

namespace Fire_Emblem;

public class GameSetup {
    private GameView _gameView;
    private string _teamsFolder;
    private JsonDataLoader _dataLoader;
    private UnitCatalog _unitCatalog;
    private AbilityCatalog _abilityCatalog;
    private TeamBuilder _teamBuilder;
    private TeamSetup _teamSetup;
    private TeamRulesSetup _teamRulesSetup;
    public GameState GameState;
    
    public GameSetup(GameView gameView, string teamsFolder) {
        _gameView = gameView;
        _teamsFolder = teamsFolder;
        _unitCatalog = new UnitCatalog();
        _abilityCatalog = new AbilityCatalog();
        _teamRulesSetup = new TeamRulesSetup();
        _dataLoader = new JsonDataLoader(_unitCatalog, _abilityCatalog);
        _teamBuilder = new TeamBuilder(_unitCatalog, _abilityCatalog);
        _teamSetup = new TeamSetup(gameView, _teamBuilder);
        GameState = new GameState();
    }

    public bool Initialize() {
        LoadData();
        LoadPlayers();
        return LoadTeamsAndValidate();
    }

    private void LoadData() {
        _dataLoader.LoadUnitCatalog(GameConfig.DefaultCharacterFilePath);
        _dataLoader.LoadAbilityCatalog(GameConfig.DefaultAbilityFilePath);
    }
    
    private void LoadPlayers() {
        GameState.PlayerOne = new Player(1);
        GameState.PlayerTwo = new Player(2);
    }

    private bool LoadTeamsAndValidate() {
        LoadTeams();
        return ValidateTeams();
    }

    private void LoadTeams() {
        var (teamOne, teamTwo) = _teamSetup.LoadTeams(_teamsFolder);
        GameState.PlayerOne.AddTeam(teamOne);
        GameState.PlayerTwo.AddTeam(teamTwo);
    }

    private bool ValidateTeams() {
        var teamRulesValidator = _teamRulesSetup.LoadRules();
        if (teamRulesValidator.IsValid(GameState.PlayerOne.Team) &&
            teamRulesValidator.IsValid(GameState.PlayerTwo.Team)) return true;
        _gameView.SayThatATeamIsInvalid();
        return false;
    }
}