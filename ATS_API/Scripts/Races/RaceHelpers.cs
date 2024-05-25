using System.Collections.Generic;
using ATS_API.Helpers;
using Eremite;
using Eremite.Buildings;
using Eremite.Model;

namespace ATS_API.Scripts.Races;

public class RaceHelpers
{
    public static void AddToWorkplaces(IEnumerable<NewRace> newRaces)
    {
        Settings settings = SO.Settings;
        
        // ProductionBuildings
        foreach (var newRace in newRaces)
        {
            var newModel = newRace.model;
            foreach (var building in settings.Buildings)
            {
                if (building is BlightPostModel blightPost)
                {
                    blightPost.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is CampModel camp)
                {
                    camp.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is CollectorModel collector)
                {
                    collector.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is ExtractorModel extractor)
                {
                    extractor.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is FarmModel farm)
                {
                    farm.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is GathererHutModel gathererHut)
                {
                    gathererHut.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is HearthModel hearth)
                {
                    hearth.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is InstitutionModel institution)
                {
                    institution.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is MineModel mine)
                {
                    mine.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is RainCatcherModel rainCatcher)
                {
                    rainCatcher.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is RelicModel relic)
                {
                    relic.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is StorageModel storage)
                {
                    storage.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
                else if (building is WorkshopModel workshop)
                {
                    workshop.workplaces.ForEach(model => model.allowedRaces = model.allowedRaces.ForceAdd(newModel));
                }
            }
        }
    }
}
