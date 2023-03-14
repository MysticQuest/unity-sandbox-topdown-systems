﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    private IMoveVector moveInterface;

    private Vector3 movePosition;

    private void Start()
    {
        moveInterface = GetComponent<IMoveVector>();
    }

    public void SetMovePosition(Vector3 direction)
    {
        moveInterface.SetVector(direction);
    }

}
