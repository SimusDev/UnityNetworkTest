using UnityEngine;
using PurrNet;
using PurrNet.Packing;
using Unity.VisualScripting;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemStack", menuName = "Resources/ItemStack")]
public class ItemStack : WorldObject, IPackedAuto
{

    [DontPack] private static uint _IDAssignment = 0;
    [DontPack] public static Dictionary<uint, ItemStack> AllByID = new();

    public int Quantity = 1;
    public uint ID
    {
        set
        {
            ID = value;
            AllByID[ID] = this;
        }
        get { return ID; }

    } 

    private void Awake()
    {
        _IDAssignment++;
        ID = _IDAssignment;
        AllByID[ID] = this;
    }

    private void OnDestroy()
    {
        AllByID.Remove(ID);
    }

    public ItemStackRef AsRef()
    {
        ItemStackRef item = new()
        {
            ID = ID
        };

        return item;
    }
}
