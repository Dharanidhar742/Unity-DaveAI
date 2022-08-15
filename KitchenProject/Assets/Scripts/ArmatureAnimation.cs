using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatureAnimation : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    { 
        animator = GetComponent<Animator>();                    //Getting Animation component
    }

    // Update is called once per frame
    void Update()
    {
        if (ThirdPersonMovement.AnimationStatus)
        {
            animator.SetBool("isWalking", true);

        }
        else animator.SetBool("isWalking", false);               //Activating Animations 
    }
}
