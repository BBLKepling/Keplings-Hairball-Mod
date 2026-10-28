using RimWorld;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class JobGiver_CatVomit : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            if (pawn == null || !HairballUtility.CatCheck(pawn.def)) return null;
            if (pawn.health.hediffSet.HasHediff(InternalDefOf.BBLK_CatLax))
            {
                Messages.Message("BBLK_CatLax_Prevent".Translate(pawn.LabelShort, pawn.Named("PAWN")), MessageTypeDefOf.PositiveEvent);
                return null;
            }
            if (pawn.Faction == null || !pawn.Faction.IsPlayer || Rand.Range(1, 101) > HairballSettings.targetedChance) return JobMaker.MakeJob(InternalDefOf.BBLK_HairballVomit);
            Job job = JobMaker.MakeJob(InternalDefOf.BBLK_TargetedVomit);
            job.locomotionUrgency = LocomotionUrgency.Sprint;
            return job;
        }
    }
}
