using Core40k;
using Verse;


namespace Cybernetics40k
{
    public class Recipe_InstallImplant_CH : Recipe_InstallImplant_C
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (!(thing is Pawn pawn && pawn.health.hediffSet.HasHediff(recipe.GetModExtension<DefModExtension_RequiresHediff>().hediffDef)) || !recipe.HasModExtension<DefModExtension_RequiresHediff>())
            {
                return false;
            }
            return base.AvailableOnNow(thing, part);
        }
    }
}