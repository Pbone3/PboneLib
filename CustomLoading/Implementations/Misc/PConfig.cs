﻿using Terraria.ModLoader.Config;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PConfig : ModConfig, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}