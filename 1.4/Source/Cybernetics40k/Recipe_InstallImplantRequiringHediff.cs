using RimWorld;
using Verse;


namespace Cybernetics40k
{
    public class Recipe_InstallImplantRequiringHediff : Recipe_InstallImplant
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