global using BTD_Mod_Helper.Extensions;
using MelonLoader;
using BTD_Mod_Helper;
using BigBloonSabatogeToggle;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Unity;
using System.Collections.Generic;

[assembly: MelonInfo(typeof(BigBloonSabatogeToggle.BigBloonSabatogeToggle), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BigBloonSabatogeToggle;

public class BigBloonSabatogeToggle : BloonsTD6Mod
{
    public static readonly ModSettingBool BigBloonSabotageToggle = new ModSettingBool(true)
    {
        displayName = "Enable Big Bloon Sabotage",
        description = "Toggles the big bloon sabotage monkey knowledge.",
    };

    public override void OnMainMenu()
    {
        ToggleBigBloonSabotage(BigBloonSabotageToggle);
    }
    public static void ToggleBigBloonSabotage(bool enable)
    {
        var player = GameExt.GetBtd6Player(Game.instance);
        var all = Game.instance.model.allKnowledge;


        var owned = new List<string>();
        foreach (var km in all)
        {
            if (player.HasKnowledge(km.name))
                owned.Add(km.name);
        }

        player.Data.acquiredKnowledge.Clear();

        foreach (var id in owned)
        {
            if (!id.Contains("BigBloonSabotage"))
                player.AcquireKnowledge(id);
        }

        if (enable)
            player.AcquireKnowledge("BigBloonSabotage");

    }

}