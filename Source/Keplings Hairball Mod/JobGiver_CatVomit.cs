using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class JobGiver_CatVomit : ThinkNode_JobGiver
    {
        public List<string> catSmall;
        public List<string> catBig;
        public override void ResolveReferences()
        {
            base.ResolveReferences();
            catSmall = InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catSmall;
            catBig = InternalDefOf.BBLK_TargetedVomit.GetModExtension<CatList_ModExtension>().catBig;
        }
        protected override Job TryGiveJob(Pawn pawn)
        {
            if (pawn == null || (!catSmall.Contains(pawn.def.defName) && (!HairballSettings.hairballBigCats || !catBig.Contains(pawn.def.defName)))) return null;
            if (pawn.Faction == null || !pawn.Faction.IsPlayer || Rand.Range(1, 101) > HairballSettings.targetedChance) return JobMaker.MakeJob(InternalDefOf.BBLK_HairballVomit);
            Job job = JobMaker.MakeJob(InternalDefOf.BBLK_TargetedVomit);
            job.locomotionUrgency = LocomotionUrgency.Sprint;
            return job;
        }
    }
}
