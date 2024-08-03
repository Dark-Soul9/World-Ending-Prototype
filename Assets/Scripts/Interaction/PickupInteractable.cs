using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class PickupInteractable : MonoBehaviour
{
    public float radius = 1f;
    bool isFocus = false;
    protected Transform player;
    public bool hasInteracted = false;

    public enum PickupType { Weapon, PickupItem}
    public PickupType currentPickupType;

    public virtual void Interact()
    {
        //hasInteracted = true;
    }
    private void Start()
    {
        GetComponent<MeshCollider>().isTrigger = true;
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
                player.GetComponent<PlayerInteraction>();
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
