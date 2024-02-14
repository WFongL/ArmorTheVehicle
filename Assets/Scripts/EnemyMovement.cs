using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float agressiveArea;
    private Animator animator;
    private Transform target;

    private void Awake() => animator = GetComponent<Animator>();

    public void StartMove(Transform target)
    {
        this.target = target;
        StartCoroutine(WorkingAgressiveArea());
    }

    public void StopMove()
    {
        StopAllCoroutines();
        animator.SetTrigger("Idle");
    }

    private IEnumerator WorkingAgressiveArea()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < agressiveArea)
            {
                StartCoroutine(RunToTarget());
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator RunToTarget()
    {
        animator.SetTrigger("Run");

        while (true)
        {
            transform.position += transform.forward * moveSpeed * Time.fixedDeltaTime;
            Vector3 direction = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
