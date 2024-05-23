using System.Collections.Generic;
using System.Linq;
using Eremite;
using Eremite.Characters.Villagers;

namespace ATS_API.Helpers;

public enum VillagerPerkTypes
{ 
    Acidic_Environment_Blightrot,
    Acidic_Environment,
    Blight_Fighter_Speed_Speed_Increase,
    Blight_No_Production,
    Charmed_Long_Break,
    Comfortable_Job,
    Extreme_Noise,
    FallenViceroyCommemoration,
    FarmersDiet,
    Faster_Woocutters,
    Forced_Improvisation,
    Furniture,
    Global_Chance_of_Death,
    Hauler_Break_Interval_villager_perk,
    Hauler_Speed_villager_perk,
    Houses_plus_1_break_time_child,
    Leisure_Worker,
    LessHostilityPerWoodcutter_Proficiency,
    MoleResolvePenalty_hard,
    MoleResolvePenalty_impossible,
    MoleResolvePenalty_normal,
    MoleResolvePenalty_very_hard,
    Poisoned_Food_Instant,
    Proficiency_Blightrot,
    Proficiency,
    Rainpunk_Comfortable,
    RottingWoodDestroyYield,
    Royal_Guard_Training_Resolve_Reward,
    SE_Hot_Springs_Villager_Resolve_Effect,
    SE_Longer_Break_Interval_child,
    SE_Mine_in_Storm,
    Shaky_Hands,
    Shorter_Break,
    SickTreesDestroyYield,
    Smart_Worker,
    Spiced_Ale,
    VaultResolvePenalty_normal,
    Very_Long_Breaks,
    U_Houses_Bonus_Resolve,
    U_Houses_Villagers_Speed_Bonus,
    Blight_Death_Chance,
    Blight_Faster_Move,
    Blight_Production_Boost,
    cMdlt_Distracted_PiercingWinds,
    cMdlt_Distracted_StrangeLights,
    cMdlt_Distracted_UnnervingSilence,
    cMdlt_Energized_FreshBreeze,
    cMdlt_Energized_InvigoratingWinds,
    cMdlt_FadingToxicRain,
    cMdlt_Fading_ColdSnap,
    cMdlt_Fading_DeadlyLights,
    cMdlt_Fading_EerieSong,
    cMdlt_Fading_Hailstorm,
    cMdlt_Focused_StrangeVisions,
    cMdlt_Focused_SunFestivities,
    cMdlt_Frustrated_Melanchory,
    cMdlt_Frustrated_Swarms,
    cMdlt_Gluttonous_ColdSnap,
    cMdlt_Gluttonous_Downpour,
    cMdlt_HomelessDeath10_RegularRain,
    cMdlt_LowResolve_HomelessInStorm,
    cMdlt_Motivated_Aurora,
    cMdlt_Motivated_EuphoricVapours,
    cMdlt_Motivated_Swarms,
    cMdlt_Slowed_Downpour,
    cMdlt_Slowed_Fog,
    cMdlt_Stagnant_Eclipse,
    cMdlt_Stagnant_Eclipse_NEW,
    cMdlt_Stagnant_NauseousSpores,
    cMdlt_Stagnant_NauseousSpores_NEW,
}


public static class VillagerPerkTypesExtensions
{
    public static string ToName(this VillagerPerkTypes type)
    {
        if (TypeToInternalName.TryGetValue(type, out var name))
        {
            return name;
        }

        Plugin.Log.LogError($"Cannot find name of Building Tag type: " + type);
        return "Alchemy";
    }
    
    public static VillagerPerkModel ToModel(this VillagerPerkTypes type)
    {
        string name = type.ToName();
        VillagerPerkModel model = SO.Settings.villagersPerks.FirstOrDefault(a=>a.name == name);
        if (model != null)
        {
            return model;
        }

        Plugin.Log.LogError("Cannot find building tag model for type: " + type + " with name: " + name);
        return null;
    }

    internal static readonly Dictionary<VillagerPerkTypes, string> TypeToInternalName = new()
    {
        { VillagerPerkTypes.Acidic_Environment_Blightrot, "Acidic Environment Blightrot" },
        { VillagerPerkTypes.Acidic_Environment, "Acidic Environment" },
        { VillagerPerkTypes.Blight_Fighter_Speed_Speed_Increase, "Blight Fighter Speed - Speed Increase" },
        { VillagerPerkTypes.Blight_No_Production, "Blight No Production" },
        { VillagerPerkTypes.Charmed_Long_Break, "Charmed (Long Break)" },
        { VillagerPerkTypes.Comfortable_Job, "Comfortable Job" },
        { VillagerPerkTypes.Extreme_Noise, "Extreme Noise" },
        { VillagerPerkTypes.FallenViceroyCommemoration, "FallenViceroyCommemoration" },
        { VillagerPerkTypes.FarmersDiet, "FarmersDiet" },
        { VillagerPerkTypes.Faster_Woocutters, "Faster Woocutters" },
        { VillagerPerkTypes.Forced_Improvisation, "Forced Improvisation" },
        { VillagerPerkTypes.Furniture, "Furniture" },
        { VillagerPerkTypes.Global_Chance_of_Death, "Global Chance of Death" },
        { VillagerPerkTypes.Hauler_Break_Interval_villager_perk, "Hauler Break Interval - villager perk" },
        { VillagerPerkTypes.Hauler_Speed_villager_perk, "Hauler Speed - villager perk" },
        { VillagerPerkTypes.Houses_plus_1_break_time_child, "Houses +1 - break time - child" },
        { VillagerPerkTypes.Leisure_Worker, "Leisure Worker" },
        { VillagerPerkTypes.LessHostilityPerWoodcutter_Proficiency, "LessHostilityPerWoodcutter - Proficiency" },
        { VillagerPerkTypes.MoleResolvePenalty_hard, "MoleResolvePenalty - hard" },
        { VillagerPerkTypes.MoleResolvePenalty_impossible, "MoleResolvePenalty - impossible" },
        { VillagerPerkTypes.MoleResolvePenalty_normal, "MoleResolvePenalty - normal" },
        { VillagerPerkTypes.MoleResolvePenalty_very_hard, "MoleResolvePenalty - very hard" },
        { VillagerPerkTypes.Poisoned_Food_Instant, "Poisoned Food Instant" },
        { VillagerPerkTypes.Proficiency_Blightrot, "Proficiency Blightrot" },
        { VillagerPerkTypes.Proficiency, "Proficiency" },
        { VillagerPerkTypes.Rainpunk_Comfortable, "Rainpunk Comfortable" },
        { VillagerPerkTypes.RottingWoodDestroyYield, "RottingWoodDestroyYield" },
        { VillagerPerkTypes.Royal_Guard_Training_Resolve_Reward, "Royal Guard Training - Resolve Reward" },
        { VillagerPerkTypes.SE_Hot_Springs_Villager_Resolve_Effect, "SE Hot Springs (Villager Resolve Effect)" },
        { VillagerPerkTypes.SE_Longer_Break_Interval_child, "SE Longer Break Interval - child" },
        { VillagerPerkTypes.SE_Mine_in_Storm, "SE Mine in Storm" },
        { VillagerPerkTypes.Shaky_Hands, "Shaky Hands" },
        { VillagerPerkTypes.Shorter_Break, "Shorter Break" },
        { VillagerPerkTypes.SickTreesDestroyYield, "SickTreesDestroyYield" },
        { VillagerPerkTypes.Smart_Worker, "Smart Worker" },
        { VillagerPerkTypes.Spiced_Ale, "Spiced Ale" },
        { VillagerPerkTypes.VaultResolvePenalty_normal, "VaultResolvePenalty - normal" },
        { VillagerPerkTypes.Very_Long_Breaks, "Very Long Breaks" },
        { VillagerPerkTypes.U_Houses_Bonus_Resolve, "[U] Houses Bonus Resolve" },
        { VillagerPerkTypes.U_Houses_Villagers_Speed_Bonus, "[U] Houses Villagers Speed Bonus" },
        { VillagerPerkTypes.Blight_Death_Chance, "Blight Death Chance" },
        { VillagerPerkTypes.Blight_Faster_Move, "Blight_Faster_Move" },
        { VillagerPerkTypes.Blight_Production_Boost, "Blight_Production_Boost" },
        { VillagerPerkTypes.cMdlt_Distracted_PiercingWinds, "cMdlt_Distracted_PiercingWinds" },
        { VillagerPerkTypes.cMdlt_Distracted_StrangeLights, "cMdlt_Distracted_StrangeLights" },
        { VillagerPerkTypes.cMdlt_Distracted_UnnervingSilence, "cMdlt_Distracted_UnnervingSilence" },
        { VillagerPerkTypes.cMdlt_Energized_FreshBreeze, "cMdlt_Energized_FreshBreeze" },
        { VillagerPerkTypes.cMdlt_Energized_InvigoratingWinds, "cMdlt_Energized_InvigoratingWinds" },
        { VillagerPerkTypes.cMdlt_FadingToxicRain, "cMdlt_FadingToxicRain" },
        { VillagerPerkTypes.cMdlt_Fading_ColdSnap, "cMdlt_Fading_ColdSnap" },
        { VillagerPerkTypes.cMdlt_Fading_DeadlyLights, "cMdlt_Fading_DeadlyLights" },
        { VillagerPerkTypes.cMdlt_Fading_EerieSong, "cMdlt_Fading_EerieSong" },
        { VillagerPerkTypes.cMdlt_Fading_Hailstorm, "cMdlt_Fading_Hailstorm" },
        { VillagerPerkTypes.cMdlt_Focused_StrangeVisions, "cMdlt_Focused_StrangeVisions" },
        { VillagerPerkTypes.cMdlt_Focused_SunFestivities, "cMdlt_Focused_SunFestivities" },
        { VillagerPerkTypes.cMdlt_Frustrated_Melanchory, "cMdlt_Frustrated_Melanchory" },
        { VillagerPerkTypes.cMdlt_Frustrated_Swarms, "cMdlt_Frustrated_Swarms" },
        { VillagerPerkTypes.cMdlt_Gluttonous_ColdSnap, "cMdlt_Gluttonous_ColdSnap" },
        { VillagerPerkTypes.cMdlt_Gluttonous_Downpour, "cMdlt_Gluttonous_Downpour" },
        { VillagerPerkTypes.cMdlt_HomelessDeath10_RegularRain, "cMdlt_HomelessDeath10_RegularRain" },
        { VillagerPerkTypes.cMdlt_LowResolve_HomelessInStorm, "cMdlt_LowResolve_HomelessInStorm" },
        { VillagerPerkTypes.cMdlt_Motivated_Aurora, "cMdlt_Motivated_Aurora" },
        { VillagerPerkTypes.cMdlt_Motivated_EuphoricVapours, "cMdlt_Motivated_EuphoricVapours" },
        { VillagerPerkTypes.cMdlt_Motivated_Swarms, "cMdlt_Motivated_Swarms" },
        { VillagerPerkTypes.cMdlt_Slowed_Downpour, "cMdlt_Slowed_Downpour" },
        { VillagerPerkTypes.cMdlt_Slowed_Fog, "cMdlt_Slowed_Fog" },
        { VillagerPerkTypes.cMdlt_Stagnant_Eclipse, "cMdlt_Stagnant_Eclipse" },
        { VillagerPerkTypes.cMdlt_Stagnant_Eclipse_NEW, "cMdlt_Stagnant_Eclipse_NEW" },
        { VillagerPerkTypes.cMdlt_Stagnant_NauseousSpores, "cMdlt_Stagnant_NauseousSpores" },
        { VillagerPerkTypes.cMdlt_Stagnant_NauseousSpores_NEW, "cMdlt_Stagnant_NauseousSpores_NEW" },
    };
}