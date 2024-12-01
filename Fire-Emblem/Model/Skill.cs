using Fire_Emblem.Combat;
using Fire_Emblem.Skills.Conditions;
using Fire_Emblem.Skills.Effects;

namespace Fire_Emblem.Model;

public class Skill {
    public string Name { get; set; }
    public string Description { get; set; }
    private List<IEffect> Effects { get; set; }
    private List<ICondition> Conditions { get; set; }

    public Skill(string name, string description, List<IEffect> effects, List<ICondition> conditions) {
        Name = name;
        Description = description;
        Effects = effects;
        Conditions = conditions;
    }
    
    public void Activate(Unit self, Unit opponent, BattleContext context) {
        if (Conditions.All(condition => condition.IsMet(self, opponent, context))) {
            foreach (var effect in Effects) {
                effect.Apply(self, opponent, context);
            }
        }
    }
    
    public void Deactivate(Unit self, Unit opponent, BattleContext context) {
        foreach (var effect in Effects) {
            effect.Remove(self, opponent, context);
        }
    }
}