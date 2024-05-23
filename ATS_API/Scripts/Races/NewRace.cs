using ATS_API.Helpers;
using Eremite.Model;

namespace ATS_API.Scripts.Races;

public class NewRace : ASyncable <RaceModel>
{
    public RaceTypes id;
    public RaceModel model;

    public override void Sync(RaceModel model)
    {
        //todo
    }
}
