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
        MoveTowards();
    }

    public void MoveTowards()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void MoveTo()
    {   
        transform.position = Vector3.MoveTowards(transform.position, direction, moveSpeed * Time.deltaTime);
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
    }
}
