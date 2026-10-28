using UnityEngine;
using Verse;

namespace Keplings_Hairball_Mod
{
    public class HairballMod : Mod
    {
        public HairballMod(ModContentPack content) : base(content)
        {
            GetSettings<HairballSettings>();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            HairballSettings.targetedChance = (int)listingStandard.SliderLabeled("BBLK_Hairball_Targeted_Change_Label".Translate() + " " + HairballSettings.targetedChance + "%", HairballSettings.targetedChance, 0, 100, tooltip: "BBLK_Hairball_Targeted_Change_ToolTip".Translate());
            listingStandard.CheckboxLabeled("BBLK_Hairball_BigCats_Label".Translate(), ref HairballSettings.hairballBigCats, "BBLK_Hairball_BigCats_ToolTip".Translate());
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory() => "BBLK_HairballSettings".Translate();
    }
}
