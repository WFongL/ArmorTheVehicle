using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy stickman;
    [SerializeField] private Car car;
    [SerializeField] private float step_z = 3f;
    [SerializeField] private float range_x = 4f;
    [SerializeField] private float stepFromCar = 50f;
    private List<Enemy> enemies = new();

    public void StartSpawn()
    {
        CreateEnemyForStart();
        StartCoroutine(Creator());
    }

    public void StopMoveAllEnemy()
    {
        foreach (Enemy enemy in enemies)
            if (enemy != null) enemy.StopMove();
    }

    public void Reset()
    {
        foreach (Enemy enemy in enemies)
            if (enemy != null) Destroy(enemy.gameObject);
        enemies.Clear();
    }

    private void CreateEnemyForStart()
    {
        var start_step_z = car.transform.position.z + 20f;

        while (start_step_z < stepFromCar)
        {
            start_step_z += step_z;
            var position = FindPosition(start_step_z);
            CreateEnemy(position);
        }
    }

    private IEnumerator Creator()
    {
        var car_z = car.transform.position.z;

        while (true)
        {
            if (car.transform.position.z > car_z + step_z)
            {
                var position = FindPosition(stepFromCar);
                CreateEnemy(position);
                car_z = car.transform.position.z;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private Vector3 FindPosition(float step_z)
    {
        var position = car.transform.position;
        position.z += step_z;
        var random_x = Random.Range(-range_x, range_x);
        position.x += random_x;
        return position;
    }

    private void CreateEnemy(Vector3 position)
    {
        var rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
        var enemy = Instantiate(stickman, position, rotation, transform);
        enemy.GetComponent<Enemy>().Initial(car);
        enemies.Add(enemy);
    }
}
