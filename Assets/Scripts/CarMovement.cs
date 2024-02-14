using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    public void Move()
    {
        var direction = transform.position + Vector3.forward;
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.fixedDeltaTime);
    }
}
