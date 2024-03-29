﻿using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PTileEntity : ModTileEntity, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}
