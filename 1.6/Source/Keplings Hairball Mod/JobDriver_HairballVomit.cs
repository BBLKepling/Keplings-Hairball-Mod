using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class JobDriver_HairballVomit : JobDriver_Vomit
    {
        protected override IEnumerable<Toil> MakeNewToils()
        {
            foreach(Toil toil in base.MakeNewToils())
            {
                if (toil.debugName != "MakeNewToils")
                {
                    yield return toil;
                }
                else
                {
                    toil.AddFinishAction(delegate
                    {
                        FilthMaker.TryMakeFilth(job.targetA.Cell, base.Map, InternalDefOf.BBLK_Filth_Hairball, pawn.LabelIndefinite());
                    });
                    yield return toil;
                }

            }
        }
    }
}
