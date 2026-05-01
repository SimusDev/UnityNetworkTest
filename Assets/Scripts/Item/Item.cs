using UnityEngine;
using PurrNet;


public class Item : MonoBehaviour
{
    private ItemStackRef stackRef;
    private ItemStack itemStack;

    
    private bool isUsing = false;
    private bool isUsingAlt = false;

    protected virtual void Start()
    {
        itemStack = stackRef.Get();
    }

    public virtual void OnUsePressed()
    {
        isUsing = true;
    }

    public virtual void OnUseReleased()
    {
        isUsing = false;
    }

    public virtual void OnAltUsePressed()
    {
        isUsingAlt = true;
    }
    public virtual void OnAltUseReleased()
    {
        isUsingAlt = false;
    }
    
    public virtual void Using() {}
    public virtual void UsingAlt() {}

    private void FixedUpdate() {
        if (isUsing)
        {
            Using();
        }
        if (isUsingAlt)
        {
            UsingAlt();
        }
    }

}
