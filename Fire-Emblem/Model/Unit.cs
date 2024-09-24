using Fire_Emblem.Combat;

namespace Fire_Emblem.Model; 

public class Unit {
    public string Name { get; set; }
    public WeaponType Weapon { get; set; }
    public GenderType Gender { get; set; }
    public string DeathQuote { get; set; }
    
    public int HP { get; set; }
    public int Atk { get; set; }
    public int Spd { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }

    public int CurrentHp;

    public List<Ability> Abilities = new List<Ability>();
    
    public Unit(string name, WeaponType weapon, GenderType gender, string deathQuote, int hp, int atk, int spd, int def, int res) {
        Name = name;
        Weapon = weapon;
        Gender = gender;
        DeathQuote = deathQuote;
        HP = hp;
        Atk = atk;
        Spd = spd;
        Def = def;
        Res = res;

        CurrentHp = hp;
    }

    public void AddAbility(Ability ability) {
        Abilities.Add(ability);
    }

    public void ActivateAbilities(CombatContext context) {
        foreach (var ability in Abilities) {
            ability.Activate(this, context);
        }
    }

    public void AddStat(StatType statType, int value) {
        switch (statType) {
            case StatType.HP:
                HP += value;
                break;
            case StatType.Atk:
                Atk += value;
                break;
            case StatType.Spd:
                Spd += value;
                break;
            case StatType.Def:
                Def += value;
                break;
            case StatType.Res:
                Res += value;
                break;
            default:
                throw new NotSupportedException("This stat hasn't been implemented yet");
        }
    }
    public void ReceiveDamage(int damage) {
        CurrentHp -= damage;
        if (CurrentHp < 0) {
            CurrentHp = 0;
        }
    }
    
    public bool IsAlive() {
        return CurrentHp > 0;
    }
}