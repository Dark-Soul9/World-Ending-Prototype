using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ActivityInteractable : MonoBehaviour
{
    bool isFocus = false;
    protected Transform player;
    public bool hasInteracted = false;

    public enum ActivityType { Animated, FadeToBlack}
    public ActivityType currentActivityType;

    public virtual void Interact()
    {
        //hasInteracted = true;
    }
    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= 1f)
            {
                Interact();
            }
        }
        else
        {
            Debug.Log("Not Happening");
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus=false;
        player = null;
        hasInteracted = false;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
    
}
