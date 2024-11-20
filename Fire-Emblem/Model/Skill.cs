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
    
    public void Activate(Unit owner, BattleContext context) {
        if (Conditions.All(condition => condition.IsMet(owner, context))) {
            foreach (var effect in Effects) {
                effect.Apply(owner, context);
            }
        }
    }
    
    public void Deactivate(Unit owner, BattleContext context) {
        foreach (var effect in Effects) {
            effect.Remove(owner, context);
        }
    }
}