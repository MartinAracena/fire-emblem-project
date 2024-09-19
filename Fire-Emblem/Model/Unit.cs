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

    public int currentHp;

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

        currentHp = hp;
    }

    public void AddAbility(Ability ability) {
        Abilities.Add(ability);
    }

    public void ReceiveDamage(int damage) {
        currentHp -= damage;
        if (currentHp < 0) {
            currentHp = 0;
        }
    }

    public bool IsAlive() {
        return currentHp > 0;
    }
}