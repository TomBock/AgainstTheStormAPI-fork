using ATS_API.Helpers;
using Eremite.Buildings;
using Eremite.Model;
using Eremite.Model.Needs;
using UnityEngine;

namespace ATS_API.Scripts.Needs;

public class NeedsBuilder
{
    public static implicit operator NewNeed(NeedsBuilder builder) =>
        builder.newNeed;
    
    public string Name => newNeed.model.name; // myguid_itemName
    
    private readonly string guid; // myGuid
    private readonly string name; // itemName
    
    private readonly NewNeed newNeed;
    
    public NeedsBuilder(string guid, string name)
    {
        this.guid = guid;
        this.name = name;
        newNeed = NeedsManager.New(guid, name);
    }

    public NeedsBuilder SetGoodPresentation(GoodModel good, LocaText description, string overrideIconPath = null)
    {
        GoodPresentationModel presentation = ScriptableObject.CreateInstance <GoodPresentationModel>();
        presentation.good = good;
        presentation.description = description;
        return SetPresentation(presentation, overrideIconPath);
    }

    public NeedsBuilder SetHousePresentation(HouseModel[] houses, string overrideIcon = null)
    {
        HousePresentationModel presentation = ScriptableObject.CreateInstance <HousePresentationModel>();
        presentation.houses = houses;
        return SetPresentation(presentation, overrideIcon);
    }

    private NeedsBuilder SetPresentation(NeedPresentationModel presentation, string overrideIconPath = null)
    {
        if (!string.IsNullOrEmpty(overrideIconPath))
        {
            presentation.overrideIcon = TextureHelper.GetImageAsSprite(
                overrideIconPath,
                TextureHelper.SpriteType.NeedOverrideIcon);
        }
        return this;
    }

    public NeedsBuilder SetCategory(NeedCategoryModel needCategory)
    {
        newNeed.model.category = needCategory;
        return this;
    }
    
    public NeedsBuilder SetEffect(ResolveEffectModel effect)
    {
        newNeed.model.effect = effect;
        return this;
    }
    
    public NeedsBuilder SetCanBeProhibited(bool value)
    {
        newNeed.model.canBeProhibited = value;
        return this;
    }
    
    public NeedsBuilder SetRequiresInstitution(bool value)
    {
        newNeed.model.requiresInstitution = value;
        return this;
    }
    
    public NeedsBuilder SetReferenceGood(GoodModel good)
    {
        newNeed.model.referenceGood = good;
        return this;
    }
    
    public NeedsBuilder SetEqualProhibitionPenalty(ResolveEffectModel resolveEffect)
    {
        newNeed.model.equalProhibitionPenalty = resolveEffect;
        return this;
    }
    
    public NeedsBuilder SetUnfairProhibitionPenalty(ResolveEffectModel resolveEffect)
    {
        newNeed.model.unfairProhibitionPenalty = resolveEffect;
        return this;
    }
    
    
}
