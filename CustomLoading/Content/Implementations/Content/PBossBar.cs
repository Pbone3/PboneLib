﻿using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PBossBar : ModBossBar, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}
