using Fire_Emblem_View;
using Fire_Emblem.Model;

namespace Fire_Emblem; 

public class GameView {
    private View _view;

    public GameView(View view) {
        _view = view;
    }
    public void WriteLine(string line) {
        _view.WriteLine(line);
    }
    public int ReadLine() {
        return int.Parse(_view.ReadLine());
    }

    public void SayToSelectFile() {
        _view.WriteLine("Elige un archivo para cargar los equipos");
    }

    public void ShowFileSelection(int index, string fileName) {
        _view.WriteLine($"{index}: {fileName}");
    }

    public void SayThatATeamIsInvalid() {
        _view.WriteLine("Archivo de equipos no válido");
    }

    public void TellAPlayerToSelectUnit(Player player) {
        _view.WriteLine($"Player {player.PlayerId} selecciona una opción");
    }
    
    public void ShowUnitSelection(Team team) {
        for (int i = 0; i < team.Units.Count; i++) {
            _view.WriteLine($"{i}: {team.Units[i].Name}");
        }
    }
    
    public void SayThatAPlayerTurnBegins(int round, Player player, Unit unit) {
        _view.WriteLine($"Round {round}: {unit.Name} (Player {player.PlayerId}) comienza");
    }
    
    public void SayThatAUnitHasWeaponAdvantage(Unit unit1, Unit unit2) {
        _view.WriteLine($"{unit1.Name} ({unit1.Weapon}) tiene ventaja con respecto a {unit2.Name} ({unit2.Weapon})");
    }
    
    public void SayThatThereIsNoWeaponAdvantage() {
        _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
    }
    public void ShowAttackInformation(Unit attacker, Unit defender, int damage) {
        _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damage} de daño");
    }
    
    public void ShowCombatResult(Unit attacker, Unit defender) {
        _view.WriteLine($"{attacker.Name} ({attacker.GetCurrentHp()}) : {defender.Name} ({defender.GetCurrentHp()})");
    }
    
    public void ShowWinner(Player player) {
        _view.WriteLine($"Player {player.PlayerId} ganó");
    }
    public void SayThatNoUnitCanDoAFollowUp() {
        _view.WriteLine($"Ninguna unidad puede hacer un follow up");
    }

    public void ShowStartOfCombatStatsChange(Stats stats) {
    }
    public void ShowFirstAttackStatChange(Stats stats) {
    }
    public void ShowFollowUpStatChange(Stats stats) {
    }
}