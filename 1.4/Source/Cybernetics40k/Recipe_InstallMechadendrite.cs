using RimWorld;
using Verse;


namespace Cybernetics40k
{
    public class Recipe_InstallMechadendrite : Recipe_InstallImplant
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (base.AvailableOnNow(thing, part))
            {
                if (thing is Pawn pawn && pawn.health.hediffSet.HasHediff(Cybernetics40kDefOf.BEWH_MechadendriteNeuralSystem))
                {
                    return true;
                }
            }
            return false;
        }
    }
}