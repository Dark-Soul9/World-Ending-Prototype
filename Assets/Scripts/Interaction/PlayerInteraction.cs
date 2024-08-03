using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PickupInteractable focusPickup;
    public ActivityInteractable focusActivity;

    
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
    
}
