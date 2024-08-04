using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

[RequireComponent(typeof(BoxCollider))]
public class PickupInteractable : MonoBehaviour
{
    private StarterAssetsInputs input;
    public float radius = 2f;
    bool isFocus = false;
    protected Transform player;
    public bool hasInteracted = false;

    public enum PickupType { Weapon, PickupItem}
    public PickupType currentPickupType;

    public virtual void Interact()
    {
        hasInteracted = true;
    }
    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<BoxCollider>().size += Vector3.up;
    }
    private void Update()
    {
        if(player != null)
        {
            if (hasInteracted)
            {
                input.interact = false;
            }
            if (isFocus && !hasInteracted && input.interact && input != null)
            {
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        if(input == null)
        {
            input = player.GetComponent<StarterAssetsInputs>();
        }
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
