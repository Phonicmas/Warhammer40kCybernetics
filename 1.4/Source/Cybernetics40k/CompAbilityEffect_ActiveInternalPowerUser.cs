using RimWorld;
using Verse;


namespace Cybernetics40k
{
    public class CompAbilityEffect_ActiveInternalPowerUser : CompAbilityEffect
    {
        HediffComp_ImplantPower ImplantPower
        {
            get
            {
                return parent.pawn.health.hediffSet.hediffs.Find(x => x.TryGetComp<HediffComp_ImplantPower>() is HediffComp_ImplantPower h).TryGetComp<HediffComp_ImplantPower>();
            }
        }

        public new CompProperties_AbilityActiveInternalPowerUser Props => (CompProperties_AbilityActiveInternalPowerUser)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            ImplantPower.DrawPower(Props.powerUsage);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            if (ImplantPower == null || !ImplantPower.HasPower(Props.powerUsage))
            {
                return false;
            }
            return base.Valid(target, throwMessages);
        }
    }
}