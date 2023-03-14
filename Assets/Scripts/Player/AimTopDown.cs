using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AimTopDown : MonoBehaviour
{
    [Header("Aim Options")]
    public Transform objectThatShoots;
    public GameObject aimTarget;
    public Transform shootTool;

    private Vector3 aimTargetTransform;
    private Vector3 aimDirection;
    private bool isPlayer = false;

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

        if (this.name == "Player")
        {
            isPlayer = true;
        }
    }

    private void Update()
    {
        Aim();
        Flip();
    }

    private void Aim()
    {
        if (isPlayer)
        {
            aimTargetTransform = Utilities.GetMousePosition();
        }
        else
        {
            aimTargetTransform = aimTarget.transform.position;
        }


        aimDirection = (aimTargetTransform - objectThatShoots.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Vector3 rotationVector = Vector3.zero;
        rotationVector.z = angle;
        shootTool.eulerAngles = rotationVector;
    }

    private void Flip()
    {
        Vector3 lookDir = Vector3.one;
        lookDir.x = Mathf.Sign(aimTargetTransform.x - transform.position.x);
        if (lookDir.x == 0) { return; }
        mainBody.localScale = lookDir;

        Vector3 weaponDir = Vector3.one;
        weaponDir.y = lookDir.x;
        shootTool.localScale = weaponDir;
    }
}