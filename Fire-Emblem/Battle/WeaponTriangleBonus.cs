using Fire_Emblem.Configuration;
using Fire_Emblem.Model;

namespace Fire_Emblem.Battle; 

public class WeaponTriangleBonus {
    private double _advantageMultiplier = GameConfig.WeaponTriangleBonus;
    private double _disadvantageMultiplier = GameConfig.WeaponTrianglePenalty;
    
    private readonly Dictionary<(WeaponType, WeaponType), double> _weaponTriangle;

    public WeaponTriangleBonus() {
        _weaponTriangle = new Dictionary<(WeaponType, WeaponType), double> {
            { (WeaponType.Sword, WeaponType.Axe), _advantageMultiplier },
            { (WeaponType.Axe, WeaponType.Lance), _advantageMultiplier },
            { (WeaponType.Lance, WeaponType.Sword), _advantageMultiplier },
            { (WeaponType.Axe, WeaponType.Sword), _disadvantageMultiplier },
            { (WeaponType.Lance, WeaponType.Axe), _disadvantageMultiplier },
            { (WeaponType.Sword, WeaponType.Lance), _disadvantageMultiplier }
        };
    }

    public double CalculateBonus(WeaponType attacker, WeaponType defender) {
        if (_weaponTriangle.TryGetValue((attacker, defender), out var bonus)){
            return bonus;
        }
        return 1.0;
    }

    public void ShowUnitAdvantage(GameView gameView, Unit attacker, Unit defender) {
        double advantage = CalculateBonus(attacker.Weapon, defender.Weapon);
        if (advantage == GameConfig.WeaponTriangleBonus) {
            gameView.SayThatAUnitHasWeaponAdvantage(attacker, defender);
        }
        else if (advantage == GameConfig.WeaponTrianglePenalty) {
            gameView.SayThatAUnitHasWeaponAdvantage(defender, attacker);
        }
        else {
            gameView.SayThatThereIsNoWeaponAdvantage();
        }
    }
}