using RimWorld;
using Verse;


namespace Cybernetics40k
{
    public class CompAbilityEffect_RechargeInternalBattery : CompAbilityEffect
    {
        HediffComp_ImplantPower ImplantPower
        {
            get
            {
                return parent?.pawn?.health?.hediffSet?.hediffs?.Find(x => x.TryGetComp<HediffComp_ImplantPower>() is HediffComp_ImplantPower h && (h != null && h.PowerRemaining < h.MaxPower)).TryGetComp<HediffComp_ImplantPower>();
            }
        }

        public new CompProperties_AbilityRechargeInternalBattery Props => (CompProperties_AbilityRechargeInternalBattery)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Thing building = (Thing)target;
            if (ImplantPower == null)
            {
                return;
            }
            int powerToTransfer = ImplantPower.MaxPower - ImplantPower.PowerRemaining;
            CompPowerBattery battery = building.TryGetComp<CompPowerBattery>();

            if (battery.StoredEnergy < powerToTransfer)
            {
                powerToTransfer = (int)battery.StoredEnergy;
            }

            battery.DrawPower(powerToTransfer);
            ImplantPower.GivePower(powerToTransfer);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            if (ImplantPower == null)
            {
                return false;
            }
            Thing building = (Thing)target;
            CompPowerBattery b = building.TryGetComp<CompPowerBattery>();
            if (b == null || b.StoredEnergy < 1)
            {
                return false;
            }
            return base.Valid(target, throwMessages);
        }
    }
}