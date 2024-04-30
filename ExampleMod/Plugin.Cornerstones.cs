﻿using ATS_API.Effects;
using Eremite.Model;
using Eremite.Model.Effects;
using Eremite.Model.Effects.Hooked;
using TextArgType = Eremite.Model.Effects.Hooked.TextArgType;

namespace ExampleMod;

public partial class Plugin
{
    private void CreateCornerstones()
    {
        CreateModdingToolsCornerstone();
    }

    private static void CreateModdingToolsCornerstone()
    {
        HookedEffectBuilder builder2 = new (PluginInfo.PLUGIN_GUID, "Modding Tools", "ModdingTools.png");
        builder2.SetObtainedAsCornerstone();
        builder2.SetAvailableInAllBiomesAndSeasons();
        builder2.SetDrawLimit(1);
        builder2.AddHook(HookFactory.AfterXNewVillagers(8));
        builder2.AddHookedEffect(EffectFactory.AddHookedEffect_IncreaseResolve(PluginInfo.PLUGIN_GUID, "UniteResolve",
            1, ResolveEffectType.Global));
 
        builder2.SetDisplayName("Modding Tools");
        builder2.SetDescription("Modders have assembled new tools that bring in new talent. " +
                                "Every {0} new Villagers gain +{1} Global Resolve.");
        builder2.SetDescriptionArgs((SourceType.Hook, TextArgType.Amount, 0), (SourceType.HookedEffect, TextArgType.Amount, 0));
        builder2.SetPreviewDescription("+{0} Global Resolve");
        builder2.SetPreviewDescriptionArgs((HookedStateTextArg.HookedStateTextSource.TotalGainIntFromHooked, 0));

        ATS_API.Plugin.Log.LogInfo(
            $"Cornerstone {builder2.Name} created {builder2.EffectModel.dynamicDescriptionArgs.Length}");
    }
}