using Alta.Forests;
using HarmonyLib;
using MelonLoader;


[assembly : MelonInfo(typeof(ForestSeedUtil.Main), "Forest Seed Utilities", "1.0.0", "Circl")]

namespace ForestSeedUtil
{
    public class Main : MelonMod
    {
        private static MelonPreferences_Category SeedCat;
        public static MelonPreferences_Entry<int> Seed { get; private set; }
        public override void OnInitializeMelon()
        {
            SeedCat = MelonPreferences.CreateCategory("ForestSeedUtil");
            Seed = (MelonPreferences_Entry<int>)SeedCat.CreateEntry<int>("Seed", -1, "Seed", false);
            MelonPreferences.Save();
        }
    }
    [HarmonyPatch]
    public class Patches
    {
        [HarmonyPatch(typeof(ForestGenerator), nameof(ForestGenerator.InitializeAsServer)), HarmonyPrefix]
        public static void SetSeedOrScedWipe(ForestGenerator __instance)
        {
            int NewSeed = Main.Seed.EditedValue;
            if (NewSeed > 0 && NewSeed != __instance.seed)
            {
                MelonLogger.Msg($"Set seed to : {NewSeed}");
                __instance.seed = NewSeed;
            }
        }

        [HarmonyPatch(typeof(ForestGenerator), nameof(ForestGenerator.InitializeAsServer)), HarmonyPostfix]
        public static void GetSeed(ForestGenerator __instance)
        {
            int NewSeed = Main.Seed.EditedValue;
            if (NewSeed < 0 )
            {
                Main.Seed.EditedValue = __instance.seed;
                MelonLogger.Msg($"Current seed : {NewSeed}");
                MelonPreferences.Save();
            }
        }
    }
}
