﻿using System.Collections.Generic;
using ATS_API.Goods;
using ATS_API.Helpers;
using Eremite.Model.Trade;

namespace ATS_API.Traders;

public class CustomTrader : ASyncable<TraderModel>
{
    public TraderTypes id;
    public TraderModel TraderModel;
    public List<string> DesiredGoods = new List<string>();
    public List<NameToAmount> GuaranteedOfferedGoods = new List<NameToAmount>();
    public List<NameToAmount> OfferedGoods = new List<NameToAmount>();
    public List<NameToAmount> Merchandise = new List<NameToAmount>();
    public Availability Availability = new Availability();

    public override void Sync(TraderModel traderModel)
    {
        traderModel.desiredGoods = DesiredGoods.GetGoods().ToArray();
        traderModel.guaranteedOfferedGoods = GuaranteedOfferedGoods.GetGoodRefs().ToArray();
        traderModel.offeredGoods = OfferedGoods.GetGoodRefWeights().ToArray();
        traderModel.merchandise = Merchandise.ToEffectDrops().ToArray();
    }
}