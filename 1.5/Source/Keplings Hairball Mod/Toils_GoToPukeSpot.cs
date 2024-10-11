using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Keplings_Hairball_Mod
{
    public static class Toils_GoToPukeSpot
    {
        public static Toil GoToPukeSpot(Pawn pawn)
        {
            Toil toil = ToilMaker.MakeToil("GoToPukeSpot");
            toil.initAction = delegate
            {
                IntVec3 cell = IntVec3.Invalid;
                Thing thing = null;
                List<int> target = new List<int>() { 1, 2, 3 };
                target.Shuffle();
                foreach (int i in target)
                {
                    thing = VomitTarget(i, pawn);
                    if (thing != null) break;
                }
                if (thing == null) RCellFinder.TryFindNearbyEmptyCell(pawn, out cell);
                else cell = thing.Position;
                if (!cell.IsValid) cell = pawn.Position;
                pawn.pather.StartPath(cell, PathEndMode.OnCell);
            };
            toil.defaultCompleteMode = ToilCompleteMode.PatherArrival;
            return toil;
        }
        public static Thing VomitTarget(int i, Pawn pawn)
        {
            switch (i)
            {
                case 1: return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForGroup(ThingRequestGroup.Bed), PathEndMode.OnCell, TraverseParms.For(pawn, mode: TraverseMode.PassDoors), 30, (Thing t) => BaseBedValidator(t) && t.Position.GetDangerFor(pawn, t.Map) == Danger.None);
                case 2: return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForGroup(ThingRequestGroup.BuildingArtificial), PathEndMode.OnCell, TraverseParms.For(pawn, mode: TraverseMode.PassDoors), 30, (Thing t) => BaseChairValidator(t) && t.Position.GetDangerFor(pawn, t.Map) == Danger.None);
                case 3: return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForGroup(ThingRequestGroup.BuildingArtificial), PathEndMode.OnCell, TraverseParms.For(pawn, mode: TraverseMode.PassDoors), 30, (Thing t) => BaseRugValidator(t) && t.Position.GetDangerFor(pawn, t.Map) == Danger.None);
                default: return null;
            }
            bool BaseBedValidator(Thing t)
            {
                if (t.def.building == null || !t.def.building.buildingTags.Contains("Bed") || t.Position.Fogged(t.Map) || t.IsBurning() || t.HostileTo(pawn))
                {
                    return false;
                }
                return true;
            }
            bool BaseChairValidator(Thing t)
            {
                if (t.def.building == null || !t.def.building.isSittable || t.Position.Fogged(t.Map) || t.IsBurning() || t.HostileTo(pawn))
                {
                    return false;
                }
                return true;
            }
            bool BaseRugValidator(Thing t)
            {
                if (t.def.building == null || !t.def.HasModExtension<CatTarget_ModExtension>() || t.Position.Fogged(t.Map) || t.IsBurning() || t.HostileTo(pawn))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
