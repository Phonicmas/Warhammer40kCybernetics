using RimWorld;
using System.Collections.Generic;
using Verse;


namespace Cybernetics40k
{
    public class HediffComp_ImplantPower : HediffComp
    {
        public HediffCompProperties_ImplantPower Props => (HediffCompProperties_ImplantPower)props;

        private int powerRemaining = 0;

        public int PowerRemaining
        {
            get => powerRemaining;
            set
            {
                if (value > MaxPower)
                {
                    powerRemaining = MaxPower;
                }
                else
                {
                    powerRemaining = value;
                }
            }
        }

        public int MaxPower
        {
            get => (int)(Props.maxPower * parent.Severity);
        }

        protected Pawn PawnOwner
        {
            get => parent.pawn;
        }

        public void DrawPower(int amount)
        {
            PowerRemaining -= amount;
        }

        public void GivePower(int amount)
        {
            PowerRemaining += amount;
        }

        public bool HasPower(int amount)
        {
            if (amount <= PowerRemaining)
            {
                return true;
            }
            return false;
        }

        public override IEnumerable<Gizmo> CompGetGizmos()
        {
            if (PawnOwner != null && PawnOwner.Faction == Faction.OfPlayer && Find.Selector.SingleSelectedThing == PawnOwner)
            {
                Gizmo_ImplantPower gizmo_ImplantPowerStatus = new Gizmo_ImplantPower();
                gizmo_ImplantPowerStatus.implant = this;
                yield return gizmo_ImplantPowerStatus;
            }
        }

        public override void Notify_PawnPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            if (Props.drainByDamageDef == dinfo.Def)
            {
                DrawPower(PowerRemaining);
            }
        }

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref powerRemaining, "powerRemaining", 0);
        }

    }
}