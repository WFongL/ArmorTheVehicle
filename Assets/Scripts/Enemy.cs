using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private float damage = 10;
    private Animator animator;
    private Car car;

    private void Awake() => animator = GetComponent<Animator>();

    public void Initial(Car car)
    {
        this.car = car;
        enemyMovement.StartMove(car.transform);
        StartCoroutine(TimeLife());
    }

    public void StopMove() => enemyMovement.StopMove();

    public void Harm()
    {
        car.TackeDammage(damage);
        StartCoroutine(HitOfCar());
    }

    public void Died()
    {
        enemyMovement.StopMove();
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var car = collision.gameObject.GetComponent<Car>();
        if (!car) return;
        animator.SetTrigger("Attack");
    }

    private IEnumerator HitOfCar()
    {
        var timeHit = 0.6f;
        while (timeHit > 0)
        {
            transform.position += transform.forward * -1 * 10 * Time.fixedDeltaTime;
            timeHit -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(10);
        Died();
    }
}
