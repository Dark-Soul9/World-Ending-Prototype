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
        if (hasInteracted)
        {
            input.interact = false;
        }
        if (input != null && input.interact)
        {
            if(currentActivityType == ActivityType.FadeToBlack)
            {
                FadeToBlack();
            }
            else if(currentActivityType == ActivityType.Animated)
            {
                AnimatedActivity();
            }
        }
    }

    void FadeToBlack()
    {
        Debug.Log("Has Interacted with FadeToBlack Activity");
    }

    void AnimatedActivity()
    {
        Debug.Log("Has Interacted with Animated Activity");
    }
}
