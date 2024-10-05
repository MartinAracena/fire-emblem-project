using Fire_Emblem.Model;

namespace Fire_Emblem.Combat;

public class CombatLog {
    private GameView _gameView;
    private Unit _unit;
    private Dictionary<CombatPhase, Stats> _bonusPhaseStats = new Dictionary<CombatPhase, Stats>();
    private Dictionary<CombatPhase, Stats> _penaltyPhaseStats = new Dictionary<CombatPhase, Stats>();

    public CombatLog(GameView gameView, Unit unit) {
        _gameView = gameView;
        _unit = unit;
        
        _bonusPhaseStats[CombatPhase.StartOfCombat] = new Stats();
        _bonusPhaseStats[CombatPhase.FirstAttack] = new Stats();
        _bonusPhaseStats[CombatPhase.FollowUpAttack] = new Stats();

        _penaltyPhaseStats[CombatPhase.StartOfCombat] = new Stats();
        _penaltyPhaseStats[CombatPhase.FirstAttack] = new Stats();
        _penaltyPhaseStats[CombatPhase.FollowUpAttack] = new Stats();
    }

    public void LogBonusStatChange(CombatPhase phase, Stats stats) {
        _bonusPhaseStats[phase] = stats;
    }
    public void LogPenaltyStatChange(CombatPhase phase, Stats stats) {
        _penaltyPhaseStats[phase] = stats;
    }
    public void GetCombatLogSummary() {
            GetPhaseSummary(CombatPhase.StartOfCombat);
            GetPhaseSummary(CombatPhase.FirstAttack);
            GetPhaseSummary(CombatPhase.FollowUpAttack);
    }
    private void GetPhaseSummary(CombatPhase phase) {
        GetStatChanges(phase, _bonusPhaseStats, "+");
        GetStatChanges(phase, _penaltyPhaseStats, "-");
    }
    private void GetStatChanges(CombatPhase phase, Dictionary<CombatPhase, Stats> phaseStats, string sign) {
        var stats = phaseStats[phase];

        foreach (StatType statType in Enum.GetValues(typeof(StatType))) {
            int value = stats.GetStat(statType);
            if (value != 0) {
                _gameView.WriteLine($"{_unit.Name} obtiene {statType} {sign}{value} en la fase {phase}");
            }
        }
    }
}