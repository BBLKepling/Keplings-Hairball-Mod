using Verse;

namespace Keplings_Hairball_Mod
{
    public class HairballUtility
    {
        private static List<ThingDef> CatSmall;
        private static List<ThingDef> CatBig;
        public static bool CatCheck(ThingDef def)
        {
            return CatSmall.Contains(def) || (HairballSettings.hairballBigCats && CatBig.Contains(def));
        }
        static HairballUtility()
        {
            CatSmall = InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catSmall;
            CatBig = InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catBig;
        }
    }
}
