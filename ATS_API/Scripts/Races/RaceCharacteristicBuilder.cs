using ATS_API.Helpers;
using Eremite;
using Eremite.Buildings;
using Eremite.Characters.Villagers;
using Eremite.Model;

namespace ATS_API.Scripts.Races;

public class RaceCharacteristicBuilder
{
    public static implicit operator RaceCharacteristicModel(RaceCharacteristicBuilder builder) =>
        builder._raceCharacteristicModel;
    
    private readonly RaceCharacteristicModel _raceCharacteristicModel;

    public RaceCharacteristicBuilder(BuildingTagModel tag)
    {
        _raceCharacteristicModel = new RaceCharacteristicModel() {tag = tag};
    }

    public RaceCharacteristicBuilder(BuildingTagTypes type) : this(type.ToModel())
    {
        
    }
    
    public RaceCharacteristicBuilder SetEffect(VillagerPerkTypes type)
    {
        return SetEffect(type.ToModel());
    }
    
    public RaceCharacteristicBuilder SetEffect(VillagerPerkModel model)
    {
        _raceCharacteristicModel.effect = model;
        return this;
    }
    
    public RaceCharacteristicBuilder SetGlobalEffect(EffectModel model)
    {
        _raceCharacteristicModel.globalEffect = model;
        return this;
    }
    
    public RaceCharacteristicBuilder SetBuildingPerk(BuildingPerkModel model)
    {
        _raceCharacteristicModel.buildingPerk = model;
        return this;
    }
}
