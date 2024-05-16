using Verse;

namespace Cybernetics40k
{
    public class HediffComp_PassiveInternalPowerUser : HediffComp
    {
        public bool isOn = true;

        HediffComp_ImplantPower ImplantPower
        {
            get
            {
                return parent?.pawn?.health?.hediffSet?.hediffs.Find(x => x.TryGetComp<HediffComp_ImplantPower>() is HediffComp_ImplantPower h).TryGetComp<HediffComp_ImplantPower>();
            }
        }

        public HediffCompProperties_PassiveInternalPowerUser Props => (HediffCompProperties_PassiveInternalPowerUser)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            if (!parent.pawn.IsHashIntervalTick(Props.tickInterval))
            {
                return;
            }
            if (ImplantPower != null && ImplantPower.HasPower(Props.powerUsage))
            {
                ImplantPower.DrawPower(Props.powerUsage);
                parent.Severity = 1;
            }
            else
            {
                parent.Severity = 0.01f;
            }
        }
    }
}