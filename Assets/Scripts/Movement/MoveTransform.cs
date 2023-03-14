using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 direction;

    private void Awake()
    {

    }

    public void SetVector(Vector3 direction)
    {
        this.direction = direction.normalized;
    }

    private void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Stop at pointer
        //transform.position = Vector3.MoveTowards(transform.position, mouseVector, moveSpeed * Time.deltaTime);
        //transform.position += keyVector.normalized * moveSpeed * Time.deltaTime;
    }
}
