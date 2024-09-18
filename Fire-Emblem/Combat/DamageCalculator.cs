using Fire_Emblem.Model;

namespace Fire_Emblem.Combat; 

public class DamageCalculator {
    private WeaponTriangleBonus _weaponTriangleBonus;

    public DamageCalculator() {
        _weaponTriangleBonus = new WeaponTriangleBonus();
    }
    public int CalculateDamage(Unit attacker, Unit defender) {
        int damage = CalculateAttack(attacker, defender) - CalculateDefense(attacker, defender);
        if (damage < 0) {
            return 0;
        }
        return damage;
    }

    private int CalculateAttack(Unit attacker, Unit defender) {
        double attack = attacker.Atk*_weaponTriangleBonus.CalculateBonus(attacker.Weapon, defender.Weapon);
        return (int)Math.Floor(attack);
    }
    private int CalculateDefense(Unit attacker, Unit defender) {
        if (attacker.Weapon == WeaponType.Magic) {
            return defender.Res;
        }
        return defender.Def;
    }
}