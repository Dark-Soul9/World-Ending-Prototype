using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : PickupInteractable
{

    public override void Interact()
    {
        PickupItem();
        base.Interact();
    }

    void PickupItem()
    {
        if(currentPickupType == PickupType.Weapon)
        {
            AddToWeapons();
        }
        else if(currentPickupType == PickupType.PickupItem)
        {
            AddToPickup();
        }
    }

    void AddToWeapons()
    {
        Debug.Log("Has Added To Weapons");
        Destroy(gameObject);
    }

    void AddToPickup()
    {
        Debug.Log("Has Added to Pickup");
        Destroy(gameObject);
    }
}
