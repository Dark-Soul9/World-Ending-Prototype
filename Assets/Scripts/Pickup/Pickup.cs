using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : PickupInteractable
{
    private StarterAssetsInputs input;

    public override void Interact()
    {
        StartActivity();
    }

    void StartActivity()
    {
        input = player.GetComponent<StarterAssetsInputs>();
        if(input != null && input.interact)
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
    }

    void AddToWeapons()
    {
        Debug.Log("Has Added To Weapons");
        hasInteracted = true;
    }

    void AddToPickup()
    {
        Debug.Log("Has Added to Pickup");
        hasInteracted = true;
    }
}
