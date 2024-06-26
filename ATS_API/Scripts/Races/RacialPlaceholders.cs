﻿using System.Linq;
using ATS_API.Helpers;
using ATS_API.Localization;
using Eremite;
using Eremite.Model;
using Eremite.Model.Sound;

namespace ATS_API.Scripts.Races;

public class RacialPlaceholders
{
    public static RacialSound AvatarClickSound => SO.Settings.Races.First().avatarClickSound;
    public static RacialSound AmbientSound => SO.Settings.Races.First().ambientSounds;
    public static SoundRef FavoringStartSound => SO.Settings.Races.First().favoringStartSound;
    // Create new object but not new key in case someone tries changing it
    public static string[] MaleNames => new[] {"A", "B"};
    // Create new object but not new key in case someone tries changing it
    public static string[] FemaleNames => new[] {"A", "B"};
    // Create new object but not new key in case someone tries changing it
    public static LocaText ResilienceLabel => ResilienceLabelKey.ToLocaText();
    public static readonly string ResilienceLabelKey = LocalizationManager.NewString(PluginInfo.PLUGIN_GUID, "placeHolders", "resilienceLabel", "Missing Label");

    public static ResolveEffectModel HungerEffect => ResolveEffectTypes.Hunger_Penalty.ToResolveEffectModel();
}
