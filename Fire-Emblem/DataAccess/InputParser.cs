using System.Text.RegularExpressions;
using Fire_Emblem.Configuration;

namespace Fire_Emblem.DataAccess;

public class InputParser {
    public Dictionary<string, List<Tuple<string, List<string>>>> ParseInput(string input) {
        var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        var playerTeams = new Dictionary<string, List<Tuple<string, List<string>>>>();
        string currentPlayer = "";
        
        foreach (var line in lines) {
            if (line.StartsWith(GameConfig.Player1TeamKey)) {
                currentPlayer = GameConfig.Player1TeamKey;

                playerTeams[currentPlayer] = new List<Tuple<string, List<string>>>();
            }
            else if (line.StartsWith(GameConfig.Player2TeamKey)) {
                currentPlayer = GameConfig.Player2TeamKey;
                playerTeams[currentPlayer] = new List<Tuple<string, List<string>>>();
            }
            else if (currentPlayer != "") {
                var match = Regex.Match(line, GameConfig.PlayerTeamPattern);

                if (match.Success)
                {
                    var unitName = match.Groups["unitName"].Value.Trim();
                    var abilities = match.Groups["abilities"].Value
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(a => a.Trim())
                        .ToList();

                    playerTeams[currentPlayer].Add(new Tuple<string, List<string>>(unitName, abilities));
                }
            }
        }
        return playerTeams;
    }
}