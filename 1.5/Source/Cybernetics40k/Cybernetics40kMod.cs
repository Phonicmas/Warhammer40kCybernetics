using HarmonyLib;
using Verse;


namespace Cybernetics40k
{
    public class Cybernetics40kMod : Mod
    {
        public static Harmony harmony;

        public Cybernetics40kMod(ModContentPack content) : base(content)
        {
            harmony = new Harmony("Cybernetics40k.Mod");
            harmony.PatchAll();
        }
    }
}