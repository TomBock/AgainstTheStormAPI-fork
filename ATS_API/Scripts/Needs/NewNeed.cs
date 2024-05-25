using ATS_API.Helpers;
using Eremite.Model;
using UnityEngine;

namespace ATS_API.Scripts.Needs;

public class NewNeed : ASyncable <NeedModel>
{
    public NeedModel model;
    public NeedTypes id;

    public override void Sync(NeedModel model)
    {
        //todo sync category?
    }
}
