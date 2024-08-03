using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Activity : ActivityInteractable
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
            Debug.Log("Has Interacted with Activity");
            Destroy(gameObject, 0.1f);
        }
    }
}
