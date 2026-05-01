using UnityEngine;
using PurrNet;
using PurrNet.Transports;
using System.Threading.Tasks;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine.InputSystem;

public class ViewModelRoot : NetworkBehaviour
{
    private ItemStack _item = null;

    protected override void OnSpawned(bool asServer)
    {
        Synchronize();
    }

    private async void Synchronize()
    {
        SetItemLocally(await GetItemFromServer());
    }

    public ItemStack GetItem()
    {
        return _item;
    }

    public void SetItemLocally(ItemStack item)
    {
        _item = item;

    }

    [ObserversRpc]
    public void SetItem(ItemStack item)
    {
        _item = item;
        SetItemLocally(_item);
    }

    [ServerRpc]
    private async Task<ItemStack> GetItemFromServer()
    {
        return _item;
    }
}
