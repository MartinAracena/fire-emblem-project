using Fire_Emblem.Battle;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Conditions; 

public class CombatPhaseCondition : ICondition {
    private CombatPhase _combatPhase;

    public CombatPhaseCondition(CombatPhase combatPhase) {
        _combatPhase = combatPhase;
    }
    public bool IsMet(Unit owner, BattleContext context) {
        return _combatPhase == context.CurrentPhase;
    }
}