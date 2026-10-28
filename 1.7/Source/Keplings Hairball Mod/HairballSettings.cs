using Verse;

namespace Keplings_Hairball_Mod
{
    public class HairballSettings : ModSettings
    {
        public static int targetedChance = 50;
        public static bool hairballBigCats = false;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref targetedChance, "targetedChance", 50);
            Scribe_Values.Look(ref hairballBigCats, "hairballBigCats", false);
            base.ExposeData();
        }
    }
}
