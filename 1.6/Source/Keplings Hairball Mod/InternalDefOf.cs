using RimWorld;
using Verse;

namespace Keplings_Hairball_Mod
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static HediffDef BBLK_CatLax;
        public static JobDef BBLK_HairballVomit;
        public static JobDef BBLK_TargetedVomit;
        public static ThingDef BBLK_Filth_Hairball;
    }
}
