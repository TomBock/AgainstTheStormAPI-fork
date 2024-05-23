using System;
using System.Linq;
using ATS_API.Helpers;
using ATS_API.Localization;
using Eremite.Model;
using HarmonyLib;
using UnityEngine;

namespace ATS_API.Scripts.Races;

public class RaceBuilder
{
    public static implicit operator CustomRace(RaceBuilder builder) =>
        builder.newModel;
    public string Name => newModel.raceModel.name;

    public CustomRace Race => newModel;

    private readonly CustomRace newModel;
    private readonly string guid; // myGuid
    private readonly string name; // itemName

    public RaceBuilder Copy(RaceModel original)
    {
       //newModel.raceModel.icon = original.icon;
       //newModel.raceModel.roundIcon = original.roundIcon;
       //newModel.raceModel.widePortrait = original.widePortrait;
       //newModel.raceModel.lowResolveNewsIcon = original.lowResolveNewsIcon;
       //newModel.raceModel.raceResolveIcon = original.raceResolveIcon;
        newModel.raceModel.isActive = original.isActive;
        newModel.raceModel.isEssential = original.isEssential;
        //model.raceModel.displayName = original.displayName;
        //newModel.raceModel.pluralName = original.pluralName;
        newModel.raceModel.shortDescription = original.shortDescription;
        newModel.raceModel.description = original.description;
        newModel.raceModel.passiveEffectDesc = original.passiveEffectDesc;
        newModel.raceModel.order = original.order;
        newModel.raceModel.assignAction = original.assignAction;
        //newModel.raceModel.tag = original.tag;
        newModel.raceModel.malePrefab = original.malePrefab;
        newModel.raceModel.femalePrefab = original.femalePrefab;
        newModel.raceModel.avatarClickSound = original.avatarClickSound;
        newModel.raceModel.ambientSounds = original.ambientSounds;
        newModel.raceModel.favoringStartSound = original.favoringStartSound;
        newModel.raceModel.maleNames = original.maleNames;
        newModel.raceModel.femaleNames = original.femaleNames;
        newModel.raceModel.baseSpeed = original.baseSpeed;
        newModel.raceModel.initialResolve = original.initialResolve;
        newModel.raceModel.minResolve = original.minResolve;
        newModel.raceModel.maxResolve = original.maxResolve;
        newModel.raceModel.resolvePositveChangePerSec = original.resolvePositveChangePerSec;
        newModel.raceModel.resolveNegativeChangePerSec = original.resolveNegativeChangePerSec;
        newModel.raceModel.resolveNegativeChangeDiffFactor = original.resolveNegativeChangeDiffFactor;
        newModel.raceModel.reputationPerSec = original.reputationPerSec;
        newModel.raceModel.minPopulationToGainReputation = original.minPopulationToGainReputation;
        newModel.raceModel.resolveForReputationTreshold = original.resolveForReputationTreshold;
        newModel.raceModel.maxReputationFromResolvePerSec = original.maxReputationFromResolvePerSec;
        newModel.raceModel.reputationTresholdIncreasePerReputation = original.reputationTresholdIncreasePerReputation;
        newModel.raceModel.resolveToReputationRatio = original.resolveToReputationRatio;
        newModel.raceModel.populationToReputationRatio = original.populationToReputationRatio;
        newModel.raceModel.resilienceLabel = original.resilienceLabel;
        newModel.raceModel.needs = original.needs;
        newModel.raceModel.racialHousingNeed = original.racialHousingNeed;
        newModel.raceModel.needsInterval = original.needsInterval;
        newModel.raceModel.hungerTolerance = original.hungerTolerance;
        newModel.raceModel.hungerEffect = original.hungerEffect;
        newModel.raceModel.homelessPenalty = original.homelessPenalty;
        newModel.raceModel.hostilityPenalty = original.hostilityPenalty;
        newModel.raceModel.initialEffects = original.initialEffects;
        newModel.raceModel.characteristics = original.characteristics;
        newModel.raceModel.deathEffects = original.deathEffects;
        newModel.raceModel.revealEffect = original.revealEffect;
        newModel.raceModel.needsCategoriesLookup = original.needsCategoriesLookup;
        newModel.raceModel.characteristicsCache = original.characteristicsCache;
        return this;
    }

    public ModelTag CreateModelTag(string name)
    {
        ModelTag tag = ScriptableObject.CreateInstance <ModelTag>();
        tag.name = name;
        return tag;
    }
    
    public RaceBuilder(string guid, string name, string iconPath)
    {
        this.guid = guid;
        this.name = name;
        RaceModel model = ScriptableObject.CreateInstance <RaceModel>();
        model.icon = TextureHelper.GetImageAsSprite(iconPath + "_icon.png", TextureHelper.SpriteType.RaceIcon);
        model.roundIcon = TextureHelper.GetImageAsSprite(iconPath + "_roundicon.png", TextureHelper.SpriteType.RaceRoundIcon);
        model.widePortrait = TextureHelper.GetImageAsSprite(iconPath + "_wideportrait.png", TextureHelper.SpriteType.RaceWidePortrait);
        model.lowResolveNewsIcon = TextureHelper.GetImageAsSprite(iconPath + "_lowresolvenewsicon.png", TextureHelper.SpriteType.RaceLowResolveNewsIcon);
        model.raceResolveIcon = TextureHelper.GetImageAsSprite(iconPath + "_resolveicon.png", TextureHelper.SpriteType.RaceResolveIcon);
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
        model.racialHousingNeed = NeedTypes.Any_Housing.ToModel(); //todo
        model.needsInterval = 120f;
        model.hungerTolerance = 3;
        model.hungerEffect = RacialPlaceholders.HungerEffect;
        model.homelessPenalty = null;       // Optional
        model.hostilityPenalty = null;      // Optional
        model.initialEffects = [];          // Optional
        model.characteristics = null;       //todo
        model.deathEffects = null;          //todo
        model.revealEffect = null;          //todo
        model.needsCategoriesLookup = null; //todo
        model.characteristicsCache = null;
        
        //todo setup as in GoodsManager?
        model.name = guid + "_" + name;
        newModel = new CustomRace()
        {
            raceModel = model,
            id = GUIDManager.Get<RaceTypes>(guid, name)
        };
    }
    
    public RaceBuilder SetCharacteristics(params RaceCharacteristicModel[] characteristicModels)
    {
        newModel.raceModel.characteristics = characteristicModels;
        return this;
    }
    
    public RaceBuilder SetHostilityPenalty(ResolveEffectModel effectModel)
    {
        newModel.raceModel.hostilityPenalty = effectModel;
        return this;
    }
    
    public RaceBuilder SetHomelessPenalty(ResolveEffectModel effectModel)
    {
        newModel.raceModel.homelessPenalty = effectModel;
        return this;
    }
    
    public RaceBuilder SetHungerEffect(ResolveEffectModel effectModel)
    {
        newModel.raceModel.hungerEffect = effectModel;
        return this;
    }

    
    public RaceBuilder SetDisplayName(string text, SystemLanguage language = SystemLanguage.English)
    {
        newModel.raceModel.displayName = LocalizationManager.ToLocaText(guid, name, "displayName", text, language);
        return this;
    }

    public RaceBuilder SetNeeds(params NeedTypes[] needTypes)
    {
        return SetNeeds(needTypes.Select(type => type.ToModel()).ToArray());
    }

    public RaceBuilder SetNeeds(params NeedModel[] needModels)
    {
        newModel.raceModel.needs = needModels;
        return this;
    }

    public RaceBuilder SetNeedsInterval(float value)
    {
        newModel.raceModel.needsInterval = value;
        return this;
    }

    public RaceBuilder SetRacialHousingNeed(NeedTypes type)
    {
        return SetRacialHousingNeed(type.ToModel());
    }
    
    public RaceBuilder SetRacialHousingNeed(NeedModel needModel)
    {
        newModel.raceModel.racialHousingNeed = needModel;
        return this;
    }
    
    public RaceBuilder SetPluralName(string text, SystemLanguage language = SystemLanguage.English)
    {
        newModel.raceModel.pluralName = LocalizationManager.ToLocaText(guid, name, "pluralName", text, language);
        return this;
    }

    /// <summary>
    /// Sets the priority 0 = Humans, 1 = Beavers, 2 = Lizards, 3 = Foxes, 3 = Harpy 
    /// </summary>
    public RaceBuilder SetOrder(int order)
    {
        newModel.raceModel.order = order;
        return this;
    }

    public RaceBuilder SetDescription(string description, SystemLanguage language = SystemLanguage.English)
    {
        newModel.raceModel.description = LocalizationManager.ToLocaText(guid, name, "description", description, language);
        if (newModel.raceModel.shortDescription == null || newModel.raceModel.shortDescription.key == Placeholders.Description.key)
        {
            newModel.raceModel.shortDescription = newModel.raceModel.description;
        }

        return this;
    }
    
    public RaceBuilder SetShortDescription(string description, SystemLanguage language = SystemLanguage.English)
    {
        newModel.raceModel.shortDescription = LocalizationManager.ToLocaText(guid, name, "shortDescription", description, language);
        if (newModel.raceModel.description == null || newModel.raceModel.description.key == Placeholders.Description.key)
        {
            newModel.raceModel.description = newModel.raceModel.shortDescription;
        }

        return this;
    }
}
