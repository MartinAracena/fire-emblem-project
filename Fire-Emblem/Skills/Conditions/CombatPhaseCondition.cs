using Fire_Emblem.Combat;
using Fire_Emblem.Model;

namespace Fire_Emblem.Abilities.Conditions; 

public class CombatPhaseCondition : ICondition {
    private CombatPhase _combatPhase;

    public CombatPhaseCondition(CombatPhase combatPhase) {
        _combatPhase = combatPhase;
    }
    public bool IsApplicable(Unit owner, CombatContext context) {
        return _combatPhase == context.CurrentPhase;
    }
}