using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    bool isFocus = false;
    Transform player;
    public bool hasInteracted = false;
    public enum interactionType { Weapon, PickUp, Activity};
    public interactionType currentInteraction;

    public virtual void Interact()
    {
        //hasInteracted = true;
    }
    private void Start()
    {
        GetComponent<SphereCollider>().radius = radius;
        GetComponent<SphereCollider>().isTrigger = true;
    }
    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
            }
        }
        else
        {
            if(player != null)
            {
                player.GetComponent<PlayerInteraction>().OnPickup();
            }
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
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
