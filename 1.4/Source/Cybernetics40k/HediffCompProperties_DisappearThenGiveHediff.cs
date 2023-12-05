using Verse;


namespace Cybernetics40k
{
    public class HediffCompProperties_DisappearThenGiveHediff : HediffCompProperties
    {
        public IntRange disappearsAfterTicks;

        public bool showRemainingTime;

        public bool canUseDecimalsShortForm;

        public MentalStateDef requiredMentalState;

        [MustTranslate]
        public string messageOnDisappear;

        public HediffDef hediffDef;

        public bool skipIfAlreadyExists;

        public HediffCompProperties_DisappearThenGiveHediff()
        {
            compClass = typeof(HediffComp_DisappearThenGiveHediff);
        }
    }
}