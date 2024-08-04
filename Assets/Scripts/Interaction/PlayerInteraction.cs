using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PickupInteractable focusPickup;
    float itemPickupRange = 2f;
    [SerializeField] LayerMask itemLayer;
    RaycastHit currentFocusedItem;
    public ActivityInteractable focusActivity;


    private void Update()
    {
        if(!IsItemInRange())
        {
            if(currentFocusedItem.transform != null)
            {
                PickupInteractable pickupInteractable = currentFocusedItem.transform.GetComponent<PickupInteractable>();
                if(pickupInteractable != null)
                {
                    RemoveFocusPickup();
                }
            }
            else
            {
                RemoveFocusActivity();
            }
        }
        else if(IsItemInRange())
        {
            PickupInteractable pickupInteractable = currentFocusedItem.transform.GetComponent<PickupInteractable>();
            if (pickupInteractable != null)
            {
                SetFocusPickup(pickupInteractable);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ActivityInteractable activityInteractable = other.GetComponent<ActivityInteractable>();
        if (activityInteractable != null)
        {
            SetFocusActivity(activityInteractable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ActivityInteractable activityInteractable = other.GetComponent<ActivityInteractable>();
        if(activityInteractable != null)
        {
            RemoveFocusActivity();
        }
    }
    void SetFocusActivity(ActivityInteractable newActivityFocus)
    {
        if(newActivityFocus != focusActivity)
        {
            if(focusActivity != null)
            {
                focusActivity.OnDefocused();
            }
            focusActivity = newActivityFocus;

        }
        newActivityFocus.OnFocused(transform);
    }
    void RemoveFocusActivity()
    {
        if (focusActivity != null)
        {
            focusActivity.OnDefocused();
        }
        focusActivity = null;
    }

    void SetFocusPickup(PickupInteractable newPickupFocus)
    {
        if (newPickupFocus != focusPickup)
        {
            if (focusPickup != null)
            {
                focusPickup.OnDefocused();
            }
            focusPickup = newPickupFocus;

        }
        newPickupFocus.OnFocused(transform);
    }
    void RemoveFocusPickup()
    {
        if (focusPickup != null)
        {
            focusPickup.OnDefocused();
        }
        focusPickup = null;
    }

    bool IsItemInRange()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, (transform.position - Camera.main.transform.position).normalized,out hitInfo, itemPickupRange, itemLayer) || Physics.Raycast(transform.position, (Camera.main.transform.position - transform.position).normalized, out hitInfo, itemPickupRange, itemLayer))
        {
            Debug.Log(hitInfo.collider.name);
            currentFocusedItem = hitInfo;
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
