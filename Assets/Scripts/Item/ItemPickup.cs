using UnityEngine;

public class ItemPickup : Interactable
{
    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        if(Input.GetButtonDown("Interact"))
        {
            Debug.Log("hasInteracted");
            hasInteracted = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
