using ATS_API.Helpers;
using Eremite.Model;

namespace ATS_API.Scripts.Races;

public class CustomRace : ASyncable <RaceModel>
{
    public RaceTypes id;
    public RaceModel raceModel;

    public override void Sync(RaceModel model)
    {
        //todo
    }
}
