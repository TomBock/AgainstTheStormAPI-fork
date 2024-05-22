using ATS_API.Helpers;
using ATS_API.Localization;
using Eremite.Model;
using UnityEngine;

namespace ATS_API.Scripts.Races;

public class RaceBuilder
{
    public string Name => model.raceModel.name;

    public CustomRace Race => model;

    private readonly CustomRace model;
    private readonly string guid; // myGuid
    private readonly string name; // itemName

    public RaceBuilder Copy(RaceModel original)
    {
        model.raceModel.icon = original.icon;
        model.raceModel.roundIcon = original.roundIcon;
        model.raceModel.widePortrait = original.widePortrait;
        model.raceModel.lowResolveNewsIcon = original.lowResolveNewsIcon;
        model.raceModel.raceResolveIcon = original.raceResolveIcon;
        model.raceModel.isActive = original.isActive;
        model.raceModel.isEssential = original.isEssential;
        //model.raceModel.displayName = original.displayName;
        model.raceModel.pluralName = original.pluralName;
        model.raceModel.shortDescription = original.shortDescription;
        model.raceModel.description = original.description;
        model.raceModel.passiveEffectDesc = original.passiveEffectDesc;
        model.raceModel.order = original.order;
        model.raceModel.assignAction = original.assignAction;
        model.raceModel.tag = original.tag;
        model.raceModel.malePrefab = original.malePrefab;
        model.raceModel.femalePrefab = original.femalePrefab;
        model.raceModel.avatarClickSound = original.avatarClickSound;
        model.raceModel.ambientSounds = original.ambientSounds;
        model.raceModel.favoringStartSound = original.favoringStartSound;
        model.raceModel.maleNames = original.maleNames;
        model.raceModel.femaleNames = original.femaleNames;
        model.raceModel.baseSpeed = original.baseSpeed;
        model.raceModel.initialResolve = original.initialResolve;
        model.raceModel.minResolve = original.minResolve;
        model.raceModel.maxResolve = original.maxResolve;
        model.raceModel.resolvePositveChangePerSec = original.resolvePositveChangePerSec;
        model.raceModel.resolveNegativeChangePerSec = original.resolveNegativeChangePerSec;
        model.raceModel.resolveNegativeChangeDiffFactor = original.resolveNegativeChangeDiffFactor;
        model.raceModel.reputationPerSec = original.reputationPerSec;
        model.raceModel.minPopulationToGainReputation = original.minPopulationToGainReputation;
        model.raceModel.resolveForReputationTreshold = original.resolveForReputationTreshold;
        model.raceModel.maxReputationFromResolvePerSec = original.maxReputationFromResolvePerSec;
        model.raceModel.reputationTresholdIncreasePerReputation = original.reputationTresholdIncreasePerReputation;
        model.raceModel.resolveToReputationRatio = original.resolveToReputationRatio;
        model.raceModel.populationToReputationRatio = original.populationToReputationRatio;
        model.raceModel.resilienceLabel = original.resilienceLabel;
        model.raceModel.needs = original.needs;
        model.raceModel.racialHousingNeed = original.racialHousingNeed;
        model.raceModel.needsInterval = original.needsInterval;
        model.raceModel.hungerTolerance = original.hungerTolerance;
        model.raceModel.hungerEffect = original.hungerEffect;
        model.raceModel.homelessPenalty = original.homelessPenalty;
        model.raceModel.hostilityPenalty = original.hostilityPenalty;
        model.raceModel.initialEffects = original.initialEffects;
        model.raceModel.characteristics = original.characteristics;
        model.raceModel.deathEffects = original.deathEffects;
        model.raceModel.revealEffect = original.revealEffect;
        model.raceModel.needsCategoriesLookup = original.needsCategoriesLookup;
        model.raceModel.characteristicsCache = original.characteristicsCache;
        return this;
    }
    
    public RaceBuilder(string guid, string name, string iconPath)
    {
        this.guid = guid;
        this.name = name;
        RaceModel model = ScriptableObject.CreateInstance <RaceModel>();
        //model.icon = TextureHelper.GetImageAsSprite(iconPath, TextureHelper.SpriteType.RaceIcon);
        //model.roundIcon = TextureHelper.GetImageAsSprite(iconPath, TextureHelper.SpriteType.RaceRoundIcon);
        //model.widePortrait = TextureHelper.GetImageAsSprite(iconPath, TextureHelper.SpriteType.RaceWidePortrait);
        //model.lowResolveNewsIcon = TextureHelper.GetImageAsSprite(iconPath, TextureHelper.SpriteType.RaceLowResolveNewsIcon);
        //model.raceResolveIcon = TextureHelper.GetImageAsSprite(iconPath, TextureHelper.SpriteType.RaceResolveIcon);
        model.isActive = true;
        model.isEssential = true;
        model.displayName = Placeholders.DisplayName;
        model.pluralName = Placeholders.DisplayName;
        model.shortDescription = Placeholders.Description;
        model.description = Placeholders.Description;
        model.passiveEffectDesc = Placeholders.Description;
        model.order = 6;
        model.assignAction = null;
        model.tag = null;
        model.malePrefab = null;
        model.femalePrefab = null;
        model.avatarClickSound = null;
        model.ambientSounds = null;
        model.favoringStartSound = null;
        model.maleNames = new[] {"A", "B"};
        model.femaleNames = new[] {"A", "B"};
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
        model.resilienceLabel = null; //todo
        model.needs = null; //todo
        model.racialHousingNeed = null; //todo
        model.needsInterval = 0f;
        model.hungerTolerance = 3;
        model.hungerEffect = null;          //todo
        model.homelessPenalty = null;       //todo
        model.hostilityPenalty = null;      //todo
        model.initialEffects = null;        //todo
        model.characteristics = null;       //todo
        model.deathEffects = null;          //todo
        model.revealEffect = null;          //todo
        model.needsCategoriesLookup = null; //todo
        model.characteristicsCache = null;
        this.model = new CustomRace()
        {
            raceModel = model,
            id = GUIDManager.Get<RaceTypes>(guid, name)
        };
    }
    
    public RaceBuilder SetDisplayName(string text, SystemLanguage language = SystemLanguage.English)
    {
        model.raceModel.displayName = LocalizationManager.ToLocaText(guid, name, "displayName", text, language);
        return this;
    }
}
