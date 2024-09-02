using System.Text.RegularExpressions;
using Fire_Emblem.DataManagement;
using Fire_Emblem.Model;

namespace Fire_Emblem.DataAccess; 

public class TeamBuilder {
    private readonly UnitCatalog _unitCatalog;
    private readonly AbilityCatalog _abilityCatalog;

    public TeamBuilder(UnitCatalog unitCatalog, AbilityCatalog abilityCatalog) {
        _unitCatalog = unitCatalog;
        _abilityCatalog = abilityCatalog;
    }
    public (Team team1, Team team2) BuildTeams(string teamFilePath) {
        Team team1 = new Team();
        Team team2 = new Team();

        Team currentTeam = null;
        
        string fileData = File.ReadAllText(teamFilePath);
        var lines = fileData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines) {
            if (line.StartsWith("Player 1 Team")) {
                currentTeam = team1;
            }
            else if (line.StartsWith("Player 2 Team")) {
                currentTeam = team2;
            }
            else {
                string[] parts = line.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0].Trim();
                string[] abilities = parts[1].Trim().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                currentTeam.AddUnit(CreateUnit(name, abilities));
            }
        }

        return (team1, team2);
    }
    

    private Unit CreateUnit(string unitName, string[] abilities) {
        var unit = _unitCatalog.GetUnit(unitName);

        foreach (var abilityName in abilities) {
            var ability = _abilityCatalog.GetAbility(abilityName);
            unit.AddAbility(ability);
        }

        return unit;
    }
}