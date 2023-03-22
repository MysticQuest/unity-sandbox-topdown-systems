using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [InjectField]
    private Transform playerTransform = null;

    private IMoveVector iMoveVector;

    private void Awake()
    {
        iMoveVector = GetComponent<IMoveVector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
