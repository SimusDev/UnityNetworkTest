using UnityEngine;
using PurrNet;
using UnityEngine.InputSystem;


public class Item : NetworkBehaviour
{
    private ItemStackRef stackRef;
    private ItemStack itemStack;

    private bool isUsing = false;
    private bool isUsingAlt = false;

    private InputAction _useAction;
    private InputAction _useAltAction;

    protected virtual void OnSpawned()
    {
        itemStack = stackRef.Get();

        if (!isOwner)
            return;

        _useAction = InputSystem.actions.FindAction("ItemUse");
        _useAltAction = InputSystem.actions.FindAction("ItemUseAlt");

        _useAction.performed += OnUseActionPerformed;
        _useAction.canceled += OnUseActionCanceled;
        _useAltAction.performed += OnUseAltActionPerformed;
        _useAltAction.canceled += OnUseAltActionCanceled;
    }

    private void OnUseActionPerformed(InputAction.CallbackContext context)
    {
        SetUsingNetworked(true);
    }

    private void OnUseActionCanceled(InputAction.CallbackContext context)
    {
        SetUsingNetworked(false);
    }

    private void OnUseAltActionPerformed(InputAction.CallbackContext context)
    {
        SetUsingAltNetworked(true);
    }

    private void OnUseAltActionCanceled(InputAction.CallbackContext context)
    {
        SetUsingAltNetworked(false);
    }

    public virtual void OnUsePressed() { }
    public virtual void OnUseReleased() { }
    public virtual void OnAltUsePressed() { }
    public virtual void OnAltUseReleased() { }
    
    public virtual void Using() {}
    public virtual void UsingAlt() {}

    private void FixedUpdate()
    {
        if (isUsing)
        {
            Using();
        }

        if (isUsingAlt)
        {
            UsingAlt();
        }

        
    }

    [ObserversRpc]
    public void SetUsingNetworked(bool value)
    {
        isUsing = value;
        OnUsePressed();
    }

    [ObserversRpc]
    public void SetUsingAltNetworked(bool value)
    {
        isUsingAlt = value;
        OnUsePressed();
    }

}
