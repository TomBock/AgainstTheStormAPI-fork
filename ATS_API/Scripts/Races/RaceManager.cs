using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ATS_API.Helpers;
using Eremite;
using Eremite.Buildings;
using Eremite.Model;
using Eremite.Services;
using UnityEngine;

namespace ATS_API.Scripts.Races;

public static partial class RaceManager
{
    public static IReadOnlyList <NewRace> NewRaces => new ReadOnlyCollection <NewRace>(s_newRaces);
    
    private static List<NewRace> s_newRaces = new List<NewRace>();
    private static List<string> s_newRaceNames = new List<string>();
    
    private static ArraySync<RaceModel, NewRace> s_races = new("New Buildings");
    
    private static GameObject s_prefabContainer;
    private static bool s_instantiated = false;
    private static bool s_dirty = false;

    public static void Tick()
    {
        if(s_dirty)
        {
            s_dirty = false;
            SyncRaces();
        }
    }
    
    internal static void Instantiate()
    {
        s_instantiated = true;
        s_dirty = true;
        
        s_prefabContainer = new GameObject("New Races");
        s_prefabContainer.transform.SetParent(Plugin.Instance.gameObject.transform);
        s_prefabContainer.SetActive(false);
    }

    private static void SyncRaces()
    {
        if (!s_instantiated)
        {
            return;
        }

        Plugin.Log.LogInfo($"Syncing {s_newRaces.Count} new races");
        
        
        RaceHelpers.AddToWorkplaces(s_newRaces);
        
        Settings settings = SO.Settings;
        s_races.Sync(ref settings.Races, settings.racesCache, s_newRaces, a => a.model);
        
        MetaStateService stateService = (MetaStateService)SO.MetaStateService;
        foreach (var newRace in s_newRaceNames)
        {
            stateService.Content.races.Add(newRace);
        }
        s_newRaceNames.Clear();
    }
    
    public static NewRace New(string guid, string name, string iconPrefix)
    {
        RaceModel model = ScriptableObject.CreateInstance <RaceModel>();
        model.icon = TextureHelper.GetImageAsSprite(iconPrefix + "_icon.png", TextureHelper.SpriteType.RaceIcon);
        model.roundIcon = TextureHelper.GetImageAsSprite(iconPrefix + "_roundicon.png", TextureHelper.SpriteType.RaceRoundIcon);
        model.widePortrait = TextureHelper.GetImageAsSprite(iconPrefix + "_wideportrait.png", TextureHelper.SpriteType.RaceWidePortrait);
        model.lowResolveNewsIcon = TextureHelper.GetImageAsSprite(iconPrefix + "_lowresolvenewsicon.png", TextureHelper.SpriteType.RaceLowResolveNewsIcon);
        model.raceResolveIcon = TextureHelper.GetImageAsSprite(iconPrefix + "_resolveicon.png", TextureHelper.SpriteType.RaceResolveIcon);
        model.isActive = true;
        model.isEssential = false;
        model.displayName = Placeholders.DisplayName;
        model.pluralName = Placeholders.DisplayName;
        model.shortDescription = Placeholders.Description;
        model.description = Placeholders.Description;
        model.passiveEffectDesc = Placeholders.Description;
        model.order = 6;
        model.assignAction = null; // Optional
        model.tag = TagTypesExtensions.GetOrCreate($"[Tag] {name}");
        model.malePrefab = null; //todo find in assetbundle
        model.femalePrefab = null; //todo find in assetbundle
        model.avatarClickSound = RacialPlaceholders.AvatarClickSound;
        model.ambientSounds = RacialPlaceholders.AmbientSound;
        model.favoringStartSound = RacialPlaceholders.FavoringStartSound;
        model.maleNames = RacialPlaceholders.MaleNames;
        model.femaleNames = RacialPlaceholders.FemaleNames;
        model.baseSpeed = 1.8f;
        model.initialResolve = 30f;
        model.minResolve = 0;
        model.maxResolve = 100;
        model.resolvePositveChangePerSec = 1f;
        model.resolveNegativeChangePerSec = 1f;
        model.resolveNegativeChangeDiffFactor = 1f;
        model.reputationPerSec = 0.02f;
        model.minPopulationToGainReputation = 1;
        model.resolveForReputationTreshold = new Vector2(0.5f, 0.9f);
        model.maxReputationFromResolvePerSec = 1f;
        model.reputationTresholdIncreasePerReputation = 0.03f;
        model.resolveToReputationRatio = 0.5f;
        model.populationToReputationRatio = 0.7f;
        model.resilienceLabel = RacialPlaceholders.ResilienceLabel;
        model.needs = [];
        model.racialHousingNeed = NeedTypes.Any_Housing.ToNeedModel();
        model.needsInterval = 120f;
        model.hungerTolerance = 3;
        model.hungerEffect = RacialPlaceholders.HungerEffect;
        model.homelessPenalty = null;       // Optional
        model.hostilityPenalty = null;      // Optional
        model.initialEffects = [];          // Optional
        model.characteristics = [];
        model.deathEffects = [];
        model.revealEffect = null;
        
        return Add(guid, name, model);
    }

    private static NewRace Add(string guid, string name, RaceModel model)
    {
        model.name = guid + "_" + name;

        RaceTypes id = GUIDManager.Get <RaceTypes>(guid, name);
        NewRace newRace = new NewRace()
        {
            model = model,
            id = id
        };
        s_newRaces.Add(newRace);
        s_newRaceNames.Add(newRace.model.name);
        RaceTypesExtensions.TypeToInternalName.Add(id, model.name);
        s_dirty = true;

        return newRace;
    }
}
