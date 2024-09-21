using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class JobDriver_HairballVomit : JobDriver_Vomit
    {
        protected override IEnumerable<Toil> MakeNewToils()
        {
            IEnumerable<Toil> baseToils = base.MakeNewToils();
            for (int i = 0; i < baseToils.Count(); i++)
            {
                if (baseToils.ElementAt(i).debugName != "MakeNewToils")
                {
                    yield return baseToils.ElementAt(i);
                    break;
                }
                Toil newToil = baseToils.ElementAt(i);
                newToil.AddFinishAction(delegate
                {
                    FilthMaker.TryMakeFilth(job.targetA.Cell, base.Map, InternalDefOf.BBLK_Filth_Hairball, pawn.LabelIndefinite());
                });
                yield return newToil;
            }
        }
    }
}
