using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Shoot : MonoBehaviour
{

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 shootEndPointPosition;
        public Vector3 shootPosition;
    }

    public Transform shootEndPointTransform;
    public ParticleSystem bulletFX;

    private AnimationControl animControl;

    [Header("Crosshair Options")]
    [SerializeField] private bool EnableCrosshair;
    [SerializeField] private Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        animControl = GetComponent<AnimationControl>();

        if (!shootEndPointTransform)
        {
            shootEndPointTransform = transform.Find("aim/hand/endPoint");
        }

        if (!bulletFX)
        {
            bulletFX = transform.Find("aim/hand/endPoint/bulletFX").GetComponent<ParticleSystem>();
        }

        if (EnableCrosshair)
        {
            hotSpot = new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animControl.IsShooting();

            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                shootEndPointPosition = shootEndPointTransform.position,
                shootPosition = Utilities.GetMousePosition(),
            });
        }
    }
}
