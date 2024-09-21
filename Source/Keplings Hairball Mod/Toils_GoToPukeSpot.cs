using RimWorld;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public class Toils_GoToPukeSpot
    {
        public static Toil GoToPukeSpot(Pawn pawn)
        {
            Toil toil = ToilMaker.MakeToil("GoToPukeSpot");
            toil.initAction = delegate
            {
                Pawn actor = toil.actor;
                IntVec3 cell = IntVec3.Invalid;
                Thing thing = null;
                thing = GenClosest.ClosestThingReachable(actor.Position, actor.Map, ThingRequest.ForGroup(ThingRequestGroup.Bed), PathEndMode.OnCell, TraverseParms.For(actor, mode: TraverseMode.PassDoors), 30, (Thing t) => BaseBedValidator(t));
                if (thing == null) RCellFinder.TryFindNearbyEmptyCell(actor, out cell);
                else cell = thing.Position;
                actor.pather.StartPath(cell, PathEndMode.OnCell);
                bool BaseBedValidator(Thing t)
                {
                    if (t.def.building == null || !t.def.building.buildingTags.Contains("Bed") || t.Position.Fogged(t.Map) || t.IsBurning() || t.HostileTo(pawn))
                    {
                        return false;
                    }
                    return true;
                }
            };
            toil.defaultCompleteMode = ToilCompleteMode.PatherArrival;
            return toil;
        }
    }
}
