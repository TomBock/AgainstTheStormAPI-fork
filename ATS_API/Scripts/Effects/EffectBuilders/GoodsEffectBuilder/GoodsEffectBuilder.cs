﻿using ATS_API.Helpers;
using Eremite.Model.Effects;

namespace ATS_API.Effects;

/// <summary>
/// Give/Remove goods from the player
/// </summary>
public class GoodsEffectBuilder : EffectBuilder<GoodsEffectModel>
{
    public class GoodEffectBuildMetaData
    {
        public NameToAmount GoodsToGive;
    }
    
    public GoodEffectBuildMetaData MetaData => m_metaData;
    
    private GoodEffectBuildMetaData m_metaData;
    
    public GoodsEffectBuilder(string guid, string name) : base(guid, name, null)
    {
        m_metaData = new GoodEffectBuildMetaData();
        m_newData.MetaData = m_metaData;
    }
    
    public void SetGood(int amount, string goodName)
    {
        m_metaData.GoodsToGive = new NameToAmount(amount, goodName);
    }
    
    public void SetGood(int amount, GoodsTypes goodsTypes)
    {
        m_metaData.GoodsToGive = new NameToAmount(amount, goodsTypes.ToName());
    }
}