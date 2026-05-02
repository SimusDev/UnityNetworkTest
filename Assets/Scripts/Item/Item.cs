using UnityEngine;
using PurrNet;
using UnityEngine.InputSystem;
using Unity.Services.Matchmaker.Models;
using Unity.IO.LowLevel.Unsafe;
using JamesFrowen.SimpleWeb;


public class Item : NetworkBehaviour
{
    private ItemStackRef stackRef;
    private ItemStack itemStack;

    private bool isUsing = false;
    private bool isUsingAlt = false;

    private InputAction _useAction;
    private InputAction _useAltAction;

    private InputAction _inspectAction;

    private Animator animator;

    private void Start()
    {
        

        animator = GetComponent<Animator>();
    //}
    //protected virtual void OnSpawned()
    //{
        itemStack = stackRef.Get();

        if (!isOwner)
            return;

        _useAction = InputSystem.actions.FindAction("ItemUse");
        _useAltAction = InputSystem.actions.FindAction("ItemUseAlt");
        _inspectAction = InputSystem.actions.FindAction("ItemInspect");

        _useAction.performed += OnUseActionPerformed;
        _useAction.canceled += OnUseActionCanceled;
        _useAltAction.performed += OnUseAltActionPerformed;
        _useAltAction.canceled += OnUseAltActionCanceled;
        _inspectAction.performed += OnInspectActionPerformed;
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

    private void OnInspectActionPerformed(InputAction.CallbackContext context)
    {
        InspectNetworked();
    }

    public virtual void OnUsePressed()
    {
        animator?.Play("Shot", 0, 0f);
    }
    public virtual void OnUseReleased() { }
    public virtual void OnAltUsePressed() { }
    public virtual void OnAltUseReleased() { }
    
    public virtual void Using() {}
    public virtual void UsingAlt() {}

    public virtual void OnInspect()
    {
        animator?.Play("Inspect", 0, 0f);
    }

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

    [ObserversRpc]

    public void InspectNetworked()
    {
        OnInspect();
    }

}
