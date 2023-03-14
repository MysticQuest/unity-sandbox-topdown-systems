using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform objectThatShoots;

    private Animator charAnimator;
    private Animator aimAnimator;

    public bool isMoving; //move this elsewhere at some point

    private void Awake()
    {
        if (!objectThatShoots)
        {
            objectThatShoots = transform.Find("aim/hand/endPoint");
        }

        charAnimator = GetComponent<Animator>();
        aimAnimator = objectThatShoots.GetComponent<Animator>();
    }

    public void IsMoving()
    {
        charAnimator.SetBool("isMoving", true);
        isMoving = true;
    }

    public void IsIdle()
    {
        charAnimator.SetBool("isMoving", false);
        isMoving = false;
    }

    public void IsShooting()
    {
        aimAnimator.SetTrigger("Shoot");
    }

}
