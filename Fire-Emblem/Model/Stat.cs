using Fire_Emblem.Utilities;

namespace Fire_Emblem.Model;

public class Stat {
    public int BaseValue { get; set; }
    public Dictionary<AttackPhase, int> Bonuses { get; set; }
    public Dictionary<AttackPhase, int> Penalties { get; set; }

    public Stat(int baseValue) {
        BaseValue = baseValue;
        Bonuses = new Dictionary<AttackPhase, int> {
            { AttackPhase.Always, 0 },
            { AttackPhase.FirstAttack, 0 },
            { AttackPhase.FollowUp, 0 },
        };
        Penalties = new Dictionary<AttackPhase, int> {
            { AttackPhase.Always, 0 },
            { AttackPhase.FirstAttack, 0 },
            { AttackPhase.FollowUp, 0 },
        };
    }
}