using System.Collections.Generic;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class JobDriver_TargetedVomit : JobDriver_HairballVomit
    {
        protected override IEnumerable<Toil> MakeNewToils()
        {
            yield return Toils_GoToPukeSpot.GoToPukeSpot(pawn);
            foreach (Toil toil in base.MakeNewToils())
            {
                yield return toil;
            }
        }
    }
}
