using System.Linq;
using ATS_API.Helpers;
using ATS_API.Localization;
using Eremite.Model;
using UnityEngine;

namespace ATS_API.Scripts.Races;

public class RaceBuilder
{
    public static implicit operator NewRace(RaceBuilder builder) =>
        builder.newRace;
    public string Name => newRace.model.name;

    public NewRace Race => newRace;

    private readonly NewRace newRace;
    private readonly string guid; // myGuid
    private readonly string name; // itemName

    public RaceBuilder Copy(RaceModel original)
    {
       //newModel.raceModel.icon = original.icon;
       //newModel.raceModel.roundIcon = original.roundIcon;
       //newModel.raceModel.widePortrait = original.widePortrait;
       //newModel.raceModel.lowResolveNewsIcon = original.lowResolveNewsIcon;
       //newModel.raceModel.raceResolveIcon = original.raceResolveIcon;
        newRace.model.isActive = original.isActive;
        newRace.model.isEssential = original.isEssential;
        //model.raceModel.displayName = original.displayName;
        //newModel.raceModel.pluralName = original.pluralName;
        newRace.model.shortDescription = original.shortDescription;
        newRace.model.description = original.description;
        newRace.model.passiveEffectDesc = original.passiveEffectDesc;
        newRace.model.order = original.order;
        newRace.model.assignAction = original.assignAction;
        //newModel.raceModel.tag = original.tag;
        newRace.model.malePrefab = original.malePrefab;
        newRace.model.femalePrefab = original.femalePrefab;
        newRace.model.avatarClickSound = original.avatarClickSound;
        newRace.model.ambientSounds = original.ambientSounds;
        newRace.model.favoringStartSound = original.favoringStartSound;
        newRace.model.maleNames = original.maleNames;
        newRace.model.femaleNames = original.femaleNames;
        newRace.model.baseSpeed = original.baseSpeed;
        newRace.model.initialResolve = original.initialResolve;
        newRace.model.minResolve = original.minResolve;
        newRace.model.maxResolve = original.maxResolve;
        newRace.model.resolvePositveChangePerSec = original.resolvePositveChangePerSec;
        newRace.model.resolveNegativeChangePerSec = original.resolveNegativeChangePerSec;
        newRace.model.resolveNegativeChangeDiffFactor = original.resolveNegativeChangeDiffFactor;
        newRace.model.reputationPerSec = original.reputationPerSec;
        newRace.model.minPopulationToGainReputation = original.minPopulationToGainReputation;
        newRace.model.resolveForReputationTreshold = original.resolveForReputationTreshold;
        newRace.model.maxReputationFromResolvePerSec = original.maxReputationFromResolvePerSec;
        newRace.model.reputationTresholdIncreasePerReputation = original.reputationTresholdIncreasePerReputation;
        newRace.model.resolveToReputationRatio = original.resolveToReputationRatio;
        newRace.model.populationToReputationRatio = original.populationToReputationRatio;
        newRace.model.resilienceLabel = original.resilienceLabel;
        newRace.model.needs = original.needs;
        newRace.model.racialHousingNeed = original.racialHousingNeed;
        newRace.model.needsInterval = original.needsInterval;
        newRace.model.hungerTolerance = original.hungerTolerance;
        newRace.model.hungerEffect = original.hungerEffect;
        newRace.model.homelessPenalty = original.homelessPenalty;
        newRace.model.hostilityPenalty = original.hostilityPenalty;
        newRace.model.initialEffects = original.initialEffects;
        newRace.model.characteristics = original.characteristics;
        newRace.model.deathEffects = original.deathEffects;
        newRace.model.revealEffect = original.revealEffect;
        newRace.model.needsCategoriesLookup = original.needsCategoriesLookup;
        newRace.model.characteristicsCache = original.characteristicsCache;
        return this;
    }
    
    public RaceBuilder(string guid, string name, string iconPrefix)
    {
        this.guid = guid;
        this.name = name;
        newRace = RaceManager.New(guid, name, iconPrefix);
    }

    public RaceBuilder SetBaseSpeed(float speed)
    {
        newRace.model.baseSpeed = speed;
        return this;
    }
    
    public RaceBuilder SetInitialResolve(float value)
    {
        newRace.model.initialResolve = value;
        return this;
    }
    
    public RaceBuilder SetMinResolve(float value)
    {
        newRace.model.minResolve = value;
        return this;
    }
    
    public RaceBuilder SetMaxResolve(float value)
    {
        newRace.model.maxResolve = value;
        return this;
    }
    
    public RaceBuilder SetResolvePositiveChangePerSec(float value)
    {
        newRace.model.resolvePositveChangePerSec = value;
        return this;
    }
    
    public RaceBuilder SetResolveNegativeChangePerSec(float value)
    {
        newRace.model.resolveNegativeChangePerSec = value;
        return this;
    }
    
    public RaceBuilder SetResolveNegativeChangeDiffFactor(float value)
    {
        newRace.model.resolveNegativeChangeDiffFactor = value;
        return this;
    }
    
    public RaceBuilder SetReputationPerSec(float value)
    {
        newRace.model.reputationPerSec = value;
        return this;
    }
    
    public RaceBuilder SetMinPopulationToGainReputation(int value)
    {
        newRace.model.minPopulationToGainReputation = value;
        return this;
    }
    
    public RaceBuilder SetResolveForReputationThreshold(Vector2 values)
    {
        newRace.model.resolveForReputationTreshold = values;
        return this;
    }
    
    public RaceBuilder SetMaxReputationFromResolvePerSec(float value)
    {
        newRace.model.maxReputationFromResolvePerSec = value;
        return this;
    }
    
    public RaceBuilder SetReputationThresholdIncreasePerReputation(float value)
    {
        newRace.model.reputationTresholdIncreasePerReputation = value;
        return this;
    }
    
    public RaceBuilder SetResolveToReputationRatio(float value)
    {
        newRace.model.resolveToReputationRatio = value;
        return this;
    }
    
    public RaceBuilder SetPopulationToReputationRatio(float value)
    {
        newRace.model.populationToReputationRatio = value;
        return this;
    }
    
    public RaceBuilder SetResilienceLabel(LocaText value)
    {
        newRace.model.resilienceLabel = value;
        return this;
    }
    
    public RaceBuilder SetHungerTolerance(int value)
    {
        newRace.model.hungerTolerance = value;
        return this;
    }

    public RaceBuilder SetInitialEffects(params ResolveEffectTypes[] effectModels)
    {
        return SetInitialEffects(effectModels.Select(m => m.ToResolveEffectModel()).ToArray());
    }
    
    public RaceBuilder SetInitialEffects(params ResolveEffectModel[] effectModels)
    {
        newRace.model.initialEffects = effectModels;
        return this;
    }

    public RaceBuilder SetDeathEffect(params EffectModel[] effectModels)
    {
        newRace.model.deathEffects = effectModels;
        return this;
    }

    public RaceBuilder SetDeathEffect(params EffectTypes[] effectTypes)
    {
        return SetDeathEffect(effectTypes.Select(type => type.ToEffectModel()).ToArray());
    }

    public RaceBuilder SetRevealEffects(EffectModel effectModel)
    {
        newRace.model.revealEffect = effectModel;
        return this;
    }

    public RaceBuilder SetRevealEffects(EffectTypes effectTypes)
    {
        return SetRevealEffects(effectTypes.ToEffectModel());
    }
    
    public RaceBuilder SetCharacteristics(params RaceCharacteristicModel[] characteristicModels)
    {
        newRace.model.characteristics = characteristicModels;
        return this;
    }
    
    public RaceBuilder SetHostilityPenalty(ResolveEffectModel effectModel)
    {
        newRace.model.hostilityPenalty = effectModel;
        return this;
    }
    
    public RaceBuilder SetHostilityPenalty(ResolveEffectTypes effectTypes)
    {
        return SetHostilityPenalty(effectTypes.ToResolveEffectModel());
    }
    
    public RaceBuilder SetHomelessPenalty(ResolveEffectModel effectModel)
    {
        newRace.model.homelessPenalty = effectModel;
        return this;
    }
    
    public RaceBuilder SetHomelessPenalty(ResolveEffectTypes effectTypes)
    {
        return SetHomelessPenalty(effectTypes.ToResolveEffectModel());
    }
    
    public RaceBuilder SetHungerEffect(ResolveEffectModel effectModel)
    {
        newRace.model.hungerEffect = effectModel;
        return this;
    }
    
    public RaceBuilder SetHungerEffect(ResolveEffectTypes effectTypes)
    {
        return SetHungerEffect(effectTypes.ToResolveEffectModel());
    }

    
    public RaceBuilder SetDisplayName(string text, SystemLanguage language = SystemLanguage.English)
    {
        newRace.model.displayName = LocalizationManager.ToLocaText(guid, name, "displayName", text, language);
        return this;
    }

    public RaceBuilder SetNeeds(params NeedTypes[] needTypes)
    {
        return SetNeeds(needTypes.Select(type => type.ToNeedModel()).ToArray());
    }

    public RaceBuilder SetNeeds(params NeedModel[] needModels)
    {
        newRace.model.needs = needModels;
        return this;
    }

    public RaceBuilder SetNeedsInterval(float value)
    {
        newRace.model.needsInterval = value;
        return this;
    }

    public RaceBuilder SetRacialHousingNeed(NeedTypes type)
    {
        return SetRacialHousingNeed(type.ToNeedModel());
    }
    
    public RaceBuilder SetRacialHousingNeed(NeedModel needModel)
    {
        newRace.model.racialHousingNeed = needModel;
        return this;
    }
    
    public RaceBuilder SetPluralName(string text, SystemLanguage language = SystemLanguage.English)
    {
        newRace.model.pluralName = LocalizationManager.ToLocaText(guid, name, "pluralName", text, language);
        return this;
    }

    /// <summary>
    /// Sets the priority 0 = Humans, 1 = Beavers, 2 = Lizards, 3 = Foxes, 3 = Harpy 
    /// </summary>
    public RaceBuilder SetOrder(int order)
    {
        newRace.model.order = order;
        return this;
    }

    public RaceBuilder SetDescription(string description, SystemLanguage language = SystemLanguage.English)
    {
        newRace.model.description = LocalizationManager.ToLocaText(guid, name, "description", description, language);
        if (newRace.model.shortDescription == null || newRace.model.shortDescription.key == Placeholders.Description.key)
        {
            newRace.model.shortDescription = newRace.model.description;
        }

        return this;
    }
    
    public RaceBuilder SetShortDescription(string description, SystemLanguage language = SystemLanguage.English)
    {
        newRace.model.shortDescription = LocalizationManager.ToLocaText(guid, name, "shortDescription", description, language);
        if (newRace.model.description == null || newRace.model.description.key == Placeholders.Description.key)
        {
            newRace.model.description = newRace.model.shortDescription;
        }

        return this;
    }

    public RaceBuilder CopyPrefab(RaceModel race)
    {
        newRace.model.malePrefab = race.malePrefab;
        newRace.model.femalePrefab = race.femalePrefab;
        return this;
    }
}
