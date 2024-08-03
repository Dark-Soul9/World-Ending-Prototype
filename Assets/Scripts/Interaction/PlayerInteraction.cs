using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable focus;

    
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null && interactable.currentInteraction == Interactable.interactionType.Activity)
        {
            SetFocus(interactable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Interactable interactable=other.GetComponent<Interactable>();
        if(interactable != null && interactable.currentInteraction == Interactable.interactionType.Activity)
        {
            RemoveFocus();
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;

        }
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
    public void OnPickup()
    {
        RemoveFocus();
    }
}
