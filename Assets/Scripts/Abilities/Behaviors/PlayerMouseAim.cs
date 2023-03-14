using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseAim : MonoBehaviour, IAim
{
    [Header("Aim Options")]
    public Transform objectThatShoots;
    public Transform shootTool;
    private Vector3 aimDirection;

    private Vector3 aimTargetTransform;

    private float angle;

    private Transform mainBody;

    private void Awake()
    {
        mainBody = transform.Find("main"); //used only in the flip placeholder function

        if (!objectThatShoots)
        {
            objectThatShoots = transform.Find("aim/hand/endPoint");
        }

        if (!shootTool)
        {
            shootTool = transform.Find("aim/hand");
        }
    }

    //private void Update()
    //{
    //    Aim();
    //    Flip();
    //}

    public void Aim(Vector3 target)
    {
        aimDirection = (target - objectThatShoots.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Vector3 rotationVector = Vector3.zero;
        rotationVector.z = angle;
        shootTool.eulerAngles = rotationVector;

        Flip(target);
    }

    private void Flip(Vector3 target)
    {
        Vector3 lookDir = Vector3.one;
        lookDir.x = Mathf.Sign(target.x - transform.position.x);
        if (lookDir.x == 0) { return; }
        mainBody.localScale = lookDir;

        Vector3 weaponDir = Vector3.one;
        weaponDir.y = lookDir.x;
        shootTool.localScale = weaponDir;
    }
}

