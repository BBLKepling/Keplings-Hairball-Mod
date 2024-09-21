using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class JobDriver_TargetedVomit : JobDriver_HairballVomit
    {
        protected override IEnumerable<Toil> MakeNewToils()
        {
            yield return (Toils_GoToPukeSpot.GoToPukeSpot(pawn));
            IEnumerable<Toil> baseToils = base.MakeNewToils();
            for (int i = 0; i < baseToils.Count(); i++)
            {
                yield return baseToils.ElementAt(i);
            }
        }
    }
}
