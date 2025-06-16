using System.Collections.Generic;
using Verse;

namespace Keplings_Hairball_Mod
{
    public class HairballUtility
    {
        private static bool listCheck;
        private static List<ThingDef> CatSmall;
        private static List<ThingDef> CatBig;
        public static bool CatCheck(ThingDef def)
        {
            if (!listCheck) CatInit();
            return CatSmall.Contains(def) || (HairballSettings.hairballBigCats && CatBig.Contains(def));
        }
        private static void CatInit()
        {
            CatSmall = InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catSmall;
            CatBig = InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catBig;
            listCheck = true;
        }
    }
}
//InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catSmall.Contains(def) || (HairballSettings.hairballBigCats && InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catBig.Contains(def))