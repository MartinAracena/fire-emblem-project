using Fire_Emblem.Combat;

namespace Fire_Emblem.Model; 

public class Unit {
    public string Name { get; set; }
    public WeaponType Weapon { get; set; }
    public GenderType Gender { get; set; }
    private string DeathQuote { get; set; }
    
    private Stats _stats { get; }

    private int _currentHp;

    public List<Skill> Skills = new List<Skill>();
    
    Unit LastEnemy  { get; set; }

    public event Action<Unit> UnitDefeated;
    
    public Unit(string name, WeaponType weapon, GenderType gender, string deathQuote, Stats stats) {
        Name = name;
        Weapon = weapon;
        Gender = gender;
        DeathQuote = deathQuote;
        _stats = stats;
        _currentHp = _stats.GetStat(StatType.Health);
    }

    public int GetCurrentHp() {
        return _currentHp;
    }

    public void AddAbility(Skill skill) {
        Skills.Add(skill);
    }

    public void ActivateAbilities(BattleContext context) {
        foreach (var ability in Skills) {
            ability.Activate(this, context);
        }
    }

    public int GetStat(StatType stat) {
        return _stats.GetStat(stat);
    }
    
    public void ReceiveDamage(int damage) {
        _currentHp -= damage;
        if (_currentHp <= 0) {
            _currentHp = 0;
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