using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeLife = 2;

    private void FixedUpdate()
    {
        MoveForvard();
        TimerLife();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (!enemy)
            return;
        HitEnemy(enemy);
    }

    private void MoveForvard()
    {
        var direction = transform.position + transform.up * -1;
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.fixedDeltaTime);
    }

    private void TimerLife()
    {
        timeLife -= Time.fixedDeltaTime;
        if (timeLife <= 0)
            Destroy(gameObject);
    }

    private void HitEnemy(Enemy enemy)
    {
        enemy.Died();
        Destroy(gameObject);
    }
}
