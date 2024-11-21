using Fire_Emblem.Combat;
using Fire_Emblem.Utilities;

namespace Fire_Emblem.Model; 

public class Unit {
    public string Name { get; set; }
    public WeaponType Weapon { get; set; }
    public GenderType Gender { get; set; }
    private string DeathQuote { get; set; }

    public Dictionary<StatType, string> Stats { get; set; }

    private int _currentHp;

    public List<Skill> Skills = new List<Skill>();
    
    Unit LastEnemy  { get; set; }

    public event Action<Unit> UnitDefeated;
    
    public Unit(string name, WeaponType weapon, GenderType gender, string deathQuote, Stats stats) {
        Name = name;
        Weapon = weapon;
        Gender = gender;
        DeathQuote = deathQuote;
        Stats = stats;
        _currentHp = Stats.GetBaseStats()[StatType.Health];
    }

    public int GetCurrentHp() {
        return _currentHp;
    }

    public void AddSkill(Skill skill) {
        Skills.Add(skill);
    }

    public void ActivateAbilities(BattleContext context) {
        foreach (var ability in Skills) {
            ability.Activate(this, context);
        }
    }
    
    public void ReceiveDamage(int damage) {
        _currentHp = Math.Max(0, _currentHp - damage);
        if (!IsAlive()) {
            OnDefeated();
        }
    }
    
    public bool IsAlive() {
        return _currentHp > 0;
    }

    protected virtual void OnDefeated() {
        UnitDefeated?.Invoke(this);
    }
}