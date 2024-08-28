using Fire_Emblem.Configuration;
using Microsoft.VisualBasic.FileIO;

namespace Fire_Emblem.DataAccess;

public class InputParser {
    public Dictionary<string, List<string>> ParseInput(string input) {
        var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        var playerTeams = new Dictionary<string, List<string>>();
        string currentPlayer = null;
        
        foreach (var line in lines) {
            if (line.StartsWith(GameConfig.Player1TeamKey)) {
                currentPlayer = GameConfig.Player1TeamKey;

                playerTeams[currentPlayer] = new List<string>();
            }
            else if (line.StartsWith(GameConfig.Player2TeamKey)) {
                currentPlayer = GameConfig.Player2TeamKey;
                playerTeams[currentPlayer] = new List<string>();
            }
            else if (currentPlayer != null) {
                playerTeams[currentPlayer].Add(line.Trim());
            }
        }
        return playerTeams;
    }
}