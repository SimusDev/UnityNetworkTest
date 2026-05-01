using PurrNet.Packing;
using UnityEngine;

public struct ItemStackRef: IPackedAuto
{
    public uint ID;

    public ItemStackRef(uint ID = 0)
    {
        this.ID = ID;
    }

    public ItemStack Get()
    {
        if (ItemStack.AllByID.TryGetValue(ID, out ItemStack item))
        {
            return item;
        }

        return null;
    }
}
