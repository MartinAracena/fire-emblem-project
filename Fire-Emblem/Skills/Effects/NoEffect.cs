using Fire_Emblem.Battle;
using Fire_Emblem.Model;

namespace Fire_Emblem.Skills.Effects;

public class NoEffect : IEffect{
    public void Apply(Unit owner, BattleContext context) {
        throw new NotImplementedException();
    }

    public void Remove(Unit owner, BattleContext context) {
        throw new NotImplementedException();
    }
}