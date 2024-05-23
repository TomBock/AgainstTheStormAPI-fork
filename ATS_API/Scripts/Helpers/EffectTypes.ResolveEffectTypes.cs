﻿using System.Collections.Generic;
using System.Linq;
using Eremite;
using Eremite.Model;

namespace ATS_API.Helpers;

public enum ResolveEffectTypes
{
    Unknown = -1,
    None,
    Biscuits_Equal_Prohibition_Penalty,
    Biscuits_Unfair_Prohibition_Penalty,
    Bloodthirst_Equal_Prohibition_Penalty,
    Bloodthirst_Unfair_Prohibition_Penalty,
    Clothes_Equal_Prohibition_Penalty,
    Clothes_Unfair_Prohibition_Penalty,
    Education_Equal_Prohibition_Penalty,
    Education_Unfair_Prohibition_Penalty,
    Jerky_Equal_Prohibition_Penalty,
    Jerky_Unfair_Prohibition_Penalty,
    Leasiure_Equal_Prohibition_Penalty,
    Leasiure_Unfair_Prohibition_Penalty,
    Luxury_Equal_Prohibition_Penalty,
    Luxury_Unfair_Prohibition_Penalty,
    Pickled_Goods_Equal_Prohibition_Penalty,
    Pickled_Goods_Unfair_Prohibition_Penalty,
    Pie_Equal_Prohibition_Penalty,
    Pie_Unfair_Prohibition_Penalty,
    Porridge_Equal_Prohibition_Penalty,
    Porridge_Unfair_Prohibition_Penalty,
    Religion_Equal_Prohibition_Penalty,
    Religion_Unfair_Prohibition_Penalty,
    Skewers_Equal_Prohibition_Penalty,
    Skewers_Unfair_Prohibition_Penalty,
    Treatment_Equal_Prohibition_Penalty,
    Treatment_Unfair_Prohibition_Penalty,
    Acidic_Environment_Blightrot,
    Acidic_Environment,
    Agriculture_Penalty,
    BattlegroundPenalty_hard,
    BattlegroundPenalty_impossible,
    BattlegroundPenalty_normal,
    BattlegroundPenalty_very_hard,
    Blightrot_Resolve,
    Blightrot_tier2,
    Blightrot_tier3,
    Cauldron_Resolve,
    Dang_Glades_Reduces_Resolve_Effect,
    DarkGatePenalty_hard,
    DarkGatePenalty_impossible,
    DarkGatePenalty_normal,
    DarkGatePenalty_very_hard,
    Explorers_Boredom,
    Extreme_Noise,
    Fishmen_Resolve,
    Forced_improvisation,
    Forsaken_Crypt_Resolve_Effect_hard,
    Forsaken_Crypt_Resolve_Effect_impossible,
    Forsaken_Crypt_Resolve_Effect_normal,
    Forsaken_Crypt_Resolve_Effect_very_hard,
    Frightening_Visions_Resolve_Effect,
    Frustrated,
    Harmony_Altar_Chaos_Resolve,
    Homelessness_Penalty,
    Hunger_Penalty,
    MoleResolvePenalty_hard,
    MoleResolvePenalty_impossible,
    MoleResolvePenalty_normal,
    MoleResolvePenalty_very_hard,
    Motivated,
    No_Fire_Penalty,
    SE_Hot_Springs_Resolve_Status,
    SE_Mine_in_Storm_Resolve_Status,
    SE_Storm_Clothes_Resolve_Status,
    Termites_Resolve_normal,
    TEST_Plague_of_Snakes_Resolve,
    Toxic_Fumes,
    Unfair_Treatment_Penalty,
    VaultResolvePenalty_normal,
    Worse_Storms_for_Hostility_Consequence_Resolve_Penalty,
    Worse_Storms_for_Hostility_Resolve_Penalty,
    Map_Mod_Resolve,
    New_Year_Penalty,
    SE_Devastating_Storms,
    Storm_Homelessness_Penalty,
    Storm_Penalty,
    T_Storm_Penalty,
    Convicts_hard,
    Convicts_impossible,
    Convicts_normal,
    Convicts_very_hard,
    Fear_of_the_Wilds_T1_hard,
    Fear_of_the_Wilds_T1_impossible,
    Fear_of_the_Wilds_T1_normal,
    Fear_of_the_Wilds_T1_very_hard,
    Fear_of_the_Wilds_T2_hard,
    Fear_of_the_Wilds_T2_impossible,
    Fear_of_the_Wilds_T2_normal,
    Fear_of_the_Wilds_T2_very_hard,
    Ancient_Artifact_weak,
    Ancient_Artifact_1,
    Ancient_Artifact_2,
    Ancient_Artifact_3,
    Beaver_Resolve_Wine,
    Beavers_Faction_Support,
    Blazing_Fire_Coal,
    Blazing_Fire_Oil,
    Blazing_Fire_Sea_Marrow,
    Blazing_Fire_Wood,
    City_Renown,
    Comfortable_Job,
    Explorer_Tales,
    FallenViceroyCommemoration,
    Favoring_Effect,
    Foxes_Faction_Support,
    Furniture,
    Generous_Rations,
    Harmony_Altar,
    Harpy_Faction_Support,
    Harpy_Resolve_Tea,
    Harpy_Stormbird_Resolve,
    Human_Resolve_Incense,
    Humans_Faction_Support,
    Institution_Global_Resolve,
    Lizard_Resolve_Training_Gear,
    Lizards_Faction_Support,
    Long_Live_the_Queen,
    Rainpunk_Comfortable,
    Rebelious_Spirit,
    Resolve_Effect_Institution_Resolve_for_Ruins,
    Resolve_Effect_Institution_Resolve_for_Sales,
    Resolve_Effect_Resolve_for_chests,
    Resolve_Effect_Resolve_for_sales,
    Resolve_Effect_Resolve_for_Standing,
    ResolveEffect_HearthEffect_Lizard,
    Royal_Guard_Training_Resolve_Effect,
    SacrificeTotemPositive,
    SE_Resolve_for_Water_Resolve_Effect,
    Spiced_Ale,
    Spices_from_the_Capital,
    Stag_Blessing,
    Stormbird_Egg_Resolve_Effect,
    Survivor_Bonding_Effect_Altar,
    Survivor_Bonding_Effect,
    Vitality,
    Wealth,
    Hub_Hub_Resolve_T1,
    Hub_Hub_Resolve_T2,
    Hub_Hub_Resolve_T3,
    TW_Global_Resolve,
    Houses_Bonus_Resolve,
    Biscuits_Effect,
    Jerky_Effect,
    Picked_Goods_Effect,
    Pie_Effect,
    Porridge_Effect,
    Skewer_Effect,
    Any_Housing_Effect,
    Beaver_Housing_Effect,
    Fox_Housing_Effect,
    Harpy_Housing_Effect,
    Human_Housing_Effect,
    Lizard_Housing_Effect,
    Bloodthirst_Effect,
    Clothes_Effect,
    Education_Effect,
    Leasiure_Effect,
    Luxury_Effect,
    Religion_Effect,
    Treatment_Effect,
    Exploring_Expedition_Resolve_Status,
    Resolve_for_Glade_Resolve_Status,
    SE_Creeping_Shadows_Resolve_Penalty_Status,
}

public static class ResolveEffectTypesExtensions
{
    internal static readonly Dictionary<ResolveEffectTypes, string> TypeToInternalName = new Dictionary<ResolveEffectTypes, string>()
    {
        { ResolveEffectTypes.Biscuits_Equal_Prohibition_Penalty, "Biscuits Equal Prohibition Penalty" },
        { ResolveEffectTypes.Biscuits_Unfair_Prohibition_Penalty, "Biscuits Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Bloodthirst_Equal_Prohibition_Penalty, "Bloodthirst Equal Prohibition Penalty" },
        { ResolveEffectTypes.Bloodthirst_Unfair_Prohibition_Penalty, "Bloodthirst Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Clothes_Equal_Prohibition_Penalty, "Clothes Equal Prohibition Penalty" },
        { ResolveEffectTypes.Clothes_Unfair_Prohibition_Penalty, "Clothes Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Education_Equal_Prohibition_Penalty, "Education Equal Prohibition Penalty" },
        { ResolveEffectTypes.Education_Unfair_Prohibition_Penalty, "Education Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Jerky_Equal_Prohibition_Penalty, "Jerky Equal Prohibition Penalty" },
        { ResolveEffectTypes.Jerky_Unfair_Prohibition_Penalty, "Jerky Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Leasiure_Equal_Prohibition_Penalty, "Leasiure Equal Prohibition Penalty" },
        { ResolveEffectTypes.Leasiure_Unfair_Prohibition_Penalty, "Leasiure Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Luxury_Equal_Prohibition_Penalty, "Luxury Equal Prohibition Penalty" },
        { ResolveEffectTypes.Luxury_Unfair_Prohibition_Penalty, "Luxury Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Pickled_Goods_Equal_Prohibition_Penalty, "Pickled Goods Equal Prohibition Penalty" },
        { ResolveEffectTypes.Pickled_Goods_Unfair_Prohibition_Penalty, "Pickled Goods Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Pie_Equal_Prohibition_Penalty, "Pie Equal Prohibition Penalty" },
        { ResolveEffectTypes.Pie_Unfair_Prohibition_Penalty, "Pie Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Porridge_Equal_Prohibition_Penalty, "Porridge Equal Prohibition Penalty" },
        { ResolveEffectTypes.Porridge_Unfair_Prohibition_Penalty, "Porridge Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Religion_Equal_Prohibition_Penalty, "Religion Equal Prohibition Penalty" },
        { ResolveEffectTypes.Religion_Unfair_Prohibition_Penalty, "Religion Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Skewers_Equal_Prohibition_Penalty, "Skewers Equal Prohibition Penalty" },
        { ResolveEffectTypes.Skewers_Unfair_Prohibition_Penalty, "Skewers Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Treatment_Equal_Prohibition_Penalty, "Treatment Equal Prohibition Penalty" },
        { ResolveEffectTypes.Treatment_Unfair_Prohibition_Penalty, "Treatment Unfair Prohibition Penalty" },
        { ResolveEffectTypes.Acidic_Environment_Blightrot, "Acidic Environment Blightrot" },
        { ResolveEffectTypes.Acidic_Environment, "Acidic Environment" },
        { ResolveEffectTypes.Agriculture_Penalty, "Agriculture Penalty" },
        { ResolveEffectTypes.BattlegroundPenalty_hard, "BattlegroundPenalty - hard" },
        { ResolveEffectTypes.BattlegroundPenalty_impossible, "BattlegroundPenalty - impossible" },
        { ResolveEffectTypes.BattlegroundPenalty_normal, "BattlegroundPenalty - normal" },
        { ResolveEffectTypes.BattlegroundPenalty_very_hard, "BattlegroundPenalty - very hard" },
        { ResolveEffectTypes.Blightrot_Resolve, "Blightrot Resolve" },
        { ResolveEffectTypes.Blightrot_tier2, "Blightrot_tier2" },
        { ResolveEffectTypes.Blightrot_tier3, "Blightrot_tier3" },
        { ResolveEffectTypes.Cauldron_Resolve, "Cauldron Resolve" },
        { ResolveEffectTypes.Dang_Glades_Reduces_Resolve_Effect, "Dang Glades Reduces Resolve Effect" },
        { ResolveEffectTypes.DarkGatePenalty_hard, "DarkGatePenalty - hard" },
        { ResolveEffectTypes.DarkGatePenalty_impossible, "DarkGatePenalty - impossible" },
        { ResolveEffectTypes.DarkGatePenalty_normal, "DarkGatePenalty - normal" },
        { ResolveEffectTypes.DarkGatePenalty_very_hard, "DarkGatePenalty - very hard" },
        { ResolveEffectTypes.Explorers_Boredom, "Explorers Boredom" },
        { ResolveEffectTypes.Extreme_Noise, "Extreme Noise" },
        { ResolveEffectTypes.Fishmen_Resolve, "Fishmen Resolve" },
        { ResolveEffectTypes.Forced_improvisation, "Forced improvisation" },
        { ResolveEffectTypes.Forsaken_Crypt_Resolve_Effect_hard, "Forsaken Crypt Resolve Effect - hard" },
        { ResolveEffectTypes.Forsaken_Crypt_Resolve_Effect_impossible, "Forsaken Crypt Resolve Effect - impossible" },
        { ResolveEffectTypes.Forsaken_Crypt_Resolve_Effect_normal, "Forsaken Crypt Resolve Effect - normal" },
        { ResolveEffectTypes.Forsaken_Crypt_Resolve_Effect_very_hard, "Forsaken Crypt Resolve Effect - very hard" },
        { ResolveEffectTypes.Frightening_Visions_Resolve_Effect, "Frightening Visions Resolve Effect" },
        { ResolveEffectTypes.Frustrated, "Frustrated" },
        { ResolveEffectTypes.Harmony_Altar_Chaos_Resolve, "Harmony Altar Chaos Resolve" },
        { ResolveEffectTypes.Homelessness_Penalty, "Homelessness Penalty" },
        { ResolveEffectTypes.Hunger_Penalty, "Hunger Penalty" },
        { ResolveEffectTypes.MoleResolvePenalty_hard, "MoleResolvePenalty - hard" },
        { ResolveEffectTypes.MoleResolvePenalty_impossible, "MoleResolvePenalty - impossible" },
        { ResolveEffectTypes.MoleResolvePenalty_normal, "MoleResolvePenalty - normal" },
        { ResolveEffectTypes.MoleResolvePenalty_very_hard, "MoleResolvePenalty - very hard" },
        { ResolveEffectTypes.Motivated, "Motivated" },
        { ResolveEffectTypes.No_Fire_Penalty, "No Fire Penalty" },
        { ResolveEffectTypes.SE_Hot_Springs_Resolve_Status, "SE Hot Springs (Resolve Status)" },
        { ResolveEffectTypes.SE_Mine_in_Storm_Resolve_Status, "SE Mine in Storm (Resolve Status)" },
        { ResolveEffectTypes.SE_Storm_Clothes_Resolve_Status, "SE Storm Clothes - Resolve Status" },
        { ResolveEffectTypes.Termites_Resolve_normal, "Termites Resolve - normal" },
        { ResolveEffectTypes.TEST_Plague_of_Snakes_Resolve, "TEST Plague of Snakes Resolve" },
        { ResolveEffectTypes.Toxic_Fumes, "Toxic Fumes" },
        { ResolveEffectTypes.Unfair_Treatment_Penalty, "Unfair Treatment Penalty" },
        { ResolveEffectTypes.VaultResolvePenalty_normal, "VaultResolvePenalty - normal" },
        { ResolveEffectTypes.Worse_Storms_for_Hostility_Consequence_Resolve_Penalty, "Worse Storms for Hostility Consequence Resolve Penalty" },
        { ResolveEffectTypes.Worse_Storms_for_Hostility_Resolve_Penalty, "Worse Storms for Hostility Resolve Penalty" },
        { ResolveEffectTypes.Map_Mod_Resolve, "[Map Mod] Resolve" },
        { ResolveEffectTypes.New_Year_Penalty, "New Year Penalty" },
        { ResolveEffectTypes.SE_Devastating_Storms, "SE Devastating Storms" },
        { ResolveEffectTypes.Storm_Homelessness_Penalty, "Storm Homelessness Penalty" },
        { ResolveEffectTypes.Storm_Penalty, "Storm Penalty" },
        { ResolveEffectTypes.T_Storm_Penalty, "T Storm Penalty" },
        { ResolveEffectTypes.Convicts_hard, "Convicts - hard" },
        { ResolveEffectTypes.Convicts_impossible, "Convicts - impossible" },
        { ResolveEffectTypes.Convicts_normal, "Convicts - normal" },
        { ResolveEffectTypes.Convicts_very_hard, "Convicts - very hard" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T1_hard, "Fear of the Wilds T1 - hard" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T1_impossible, "Fear of the Wilds T1 - impossible" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T1_normal, "Fear of the Wilds T1 - normal" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T1_very_hard, "Fear of the Wilds T1 - very hard" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T2_hard, "Fear of the Wilds T2 - hard" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T2_impossible, "Fear of the Wilds T2 - impossible" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T2_normal, "Fear of the Wilds T2 - normal" },
        { ResolveEffectTypes.Fear_of_the_Wilds_T2_very_hard, "Fear of the Wilds T2 - very hard" },
        { ResolveEffectTypes.Ancient_Artifact_weak, "Ancient Artifact - weak" },
        { ResolveEffectTypes.Ancient_Artifact_1, "Ancient Artifact 1" },
        { ResolveEffectTypes.Ancient_Artifact_2, "Ancient Artifact 2" },
        { ResolveEffectTypes.Ancient_Artifact_3, "Ancient Artifact 3" },
        { ResolveEffectTypes.Beaver_Resolve_Wine, "Beaver Resolve Wine" },
        { ResolveEffectTypes.Beavers_Faction_Support, "Beavers Faction Support" },
        { ResolveEffectTypes.Blazing_Fire_Coal, "Blazing Fire (Coal)" },
        { ResolveEffectTypes.Blazing_Fire_Oil, "Blazing Fire (Oil)" },
        { ResolveEffectTypes.Blazing_Fire_Sea_Marrow, "Blazing Fire (Sea Marrow)" },
        { ResolveEffectTypes.Blazing_Fire_Wood, "Blazing Fire (Wood)" },
        { ResolveEffectTypes.City_Renown, "City Renown" },
        { ResolveEffectTypes.Comfortable_Job, "Comfortable Job" },
        { ResolveEffectTypes.Explorer_Tales, "Explorer Tales" },
        { ResolveEffectTypes.FallenViceroyCommemoration, "FallenViceroyCommemoration" },
        { ResolveEffectTypes.Favoring_Effect, "Favoring Effect" },
        { ResolveEffectTypes.Foxes_Faction_Support, "Foxes Faction Support" },
        { ResolveEffectTypes.Furniture, "Furniture" },
        { ResolveEffectTypes.Generous_Rations, "Generous Rations" },
        { ResolveEffectTypes.Harmony_Altar, "Harmony Altar" },
        { ResolveEffectTypes.Harpy_Faction_Support, "Harpy Faction Support" },
        { ResolveEffectTypes.Harpy_Resolve_Tea, "Harpy Resolve Tea" },
        { ResolveEffectTypes.Harpy_Stormbird_Resolve, "Harpy Stormbird Resolve" },
        { ResolveEffectTypes.Human_Resolve_Incense, "Human Resolve Incense" },
        { ResolveEffectTypes.Humans_Faction_Support, "Humans Faction Support" },
        { ResolveEffectTypes.Institution_Global_Resolve, "Institution Global Resolve" },
        { ResolveEffectTypes.Lizard_Resolve_Training_Gear, "Lizard Resolve Training Gear" },
        { ResolveEffectTypes.Lizards_Faction_Support, "Lizards Faction Support" },
        { ResolveEffectTypes.Long_Live_the_Queen, "Long Live the Queen" },
        { ResolveEffectTypes.Rainpunk_Comfortable, "Rainpunk Comfortable" },
        { ResolveEffectTypes.Rebelious_Spirit, "Rebelious Spirit" },
        { ResolveEffectTypes.Resolve_Effect_Institution_Resolve_for_Ruins, "Resolve Effect - Institution Resolve for Ruins" },
        { ResolveEffectTypes.Resolve_Effect_Institution_Resolve_for_Sales, "Resolve Effect - Institution Resolve for Sales" },
        { ResolveEffectTypes.Resolve_Effect_Resolve_for_chests, "Resolve Effect - Resolve for chests" },
        { ResolveEffectTypes.Resolve_Effect_Resolve_for_sales, "Resolve Effect - Resolve for sales" },
        { ResolveEffectTypes.Resolve_Effect_Resolve_for_Standing, "Resolve Effect - Resolve for Standing" },
        { ResolveEffectTypes.ResolveEffect_HearthEffect_Lizard, "ResolveEffect_HearthEffect_Lizard" },
        { ResolveEffectTypes.Royal_Guard_Training_Resolve_Effect, "Royal Guard Training - Resolve Effect" },
        { ResolveEffectTypes.SacrificeTotemPositive, "SacrificeTotemPositive" },
        { ResolveEffectTypes.SE_Resolve_for_Water_Resolve_Effect, "SE Resolve for Water - Resolve Effect" },
        { ResolveEffectTypes.Spiced_Ale, "Spiced Ale" },
        { ResolveEffectTypes.Spices_from_the_Capital, "Spices from the Capital" },
        { ResolveEffectTypes.Stag_Blessing, "Stag Blessing" },
        { ResolveEffectTypes.Stormbird_Egg_Resolve_Effect, "Stormbird Egg - Resolve Effect" },
        { ResolveEffectTypes.Survivor_Bonding_Effect_Altar, "Survivor Bonding Effect - Altar" },
        { ResolveEffectTypes.Survivor_Bonding_Effect, "Survivor Bonding Effect" },
        { ResolveEffectTypes.Vitality, "Vitality" },
        { ResolveEffectTypes.Wealth, "Wealth" },
        { ResolveEffectTypes.Hub_Hub_Resolve_T1, "[Hub] Hub Resolve T1" },
        { ResolveEffectTypes.Hub_Hub_Resolve_T2, "[Hub] Hub Resolve T2" },
        { ResolveEffectTypes.Hub_Hub_Resolve_T3, "[Hub] Hub Resolve T3" },
        { ResolveEffectTypes.TW_Global_Resolve, "[TW] Global Resolve" },
        { ResolveEffectTypes.Houses_Bonus_Resolve, "Houses Bonus Resolve" },
        { ResolveEffectTypes.Biscuits_Effect, "Biscuits Effect" },
        { ResolveEffectTypes.Jerky_Effect, "Jerky Effect" },
        { ResolveEffectTypes.Picked_Goods_Effect, "Picked Goods Effect" },
        { ResolveEffectTypes.Pie_Effect, "Pie Effect" },
        { ResolveEffectTypes.Porridge_Effect, "Porridge Effect" },
        { ResolveEffectTypes.Skewer_Effect, "Skewer Effect" },
        { ResolveEffectTypes.Any_Housing_Effect, "Any Housing Effect" },
        { ResolveEffectTypes.Beaver_Housing_Effect, "Beaver Housing Effect" },
        { ResolveEffectTypes.Fox_Housing_Effect, "Fox Housing Effect" },
        { ResolveEffectTypes.Harpy_Housing_Effect, "Harpy Housing Effect" },
        { ResolveEffectTypes.Human_Housing_Effect, "Human Housing Effect" },
        { ResolveEffectTypes.Lizard_Housing_Effect, "Lizard Housing Effect" },
        { ResolveEffectTypes.Bloodthirst_Effect, "Bloodthirst Effect" },
        { ResolveEffectTypes.Clothes_Effect, "Clothes Effect" },
        { ResolveEffectTypes.Education_Effect, "Education Effect" },
        { ResolveEffectTypes.Leasiure_Effect, "Leasiure Effect" },
        { ResolveEffectTypes.Luxury_Effect, "Luxury Effect" },
        { ResolveEffectTypes.Religion_Effect, "Religion Effect" },
        { ResolveEffectTypes.Treatment_Effect, "Treatment Effect" },
        { ResolveEffectTypes.Exploring_Expedition_Resolve_Status, "Exploring Expedition - Resolve Status" },
        { ResolveEffectTypes.Resolve_for_Glade_Resolve_Status, "Resolve for Glade - Resolve Status" },
        { ResolveEffectTypes.SE_Creeping_Shadows_Resolve_Penalty_Status, "SE Creeping Shadows - Resolve Penalty Status" },
    };
    public static string ToName(this ResolveEffectTypes type)
    {
        if (TypeToInternalName.TryGetValue(type, out var name))
        {
            return name;
        }

        Plugin.Log.LogError($"Cannot find name of {typeof(ResolveEffectTypes)} type: " + type);
        return ResolveEffectTypes.Biscuits_Equal_Prohibition_Penalty.ToName();
    }

    public static ResolveEffectModel ToModel(this ResolveEffectTypes type)
    {
        return SO.Settings.resolveEffects.FirstOrDefault(model => model.Name == type.ToName());
    }
}
