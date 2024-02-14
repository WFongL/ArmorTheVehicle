using System;
using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarMovement carMovement;
    [SerializeField] private Turret turretRotation;
    [SerializeField] private TouchObserver touchObserver;
    [SerializeField] private float health = 100f;
    private float healthCurrently;

    public event Action<float> ChangeHealth;
    public event Action Died;

    private void Awake() => healthCurrently = health;

    public void Reset()
    {
        turretRotation.Reset();
        healthCurrently = health;
        ChangeHealth?.Invoke(healthCurrently / health);
    }

    public void TackeDammage(float power)
    {
        healthCurrently -= power;
        ChangeHealth?.Invoke(healthCurrently / health);
        if (healthCurrently <= 0)
        {
            Died?.Invoke();
        }
    }

    public void StartMove()
    {
        StartCoroutine(Working());
    }

    public void StopMove()
    {
        StopAllCoroutines();
    }

    private IEnumerator Working()
    {
        while (true)
        {
            carMovement.Move();
            turretRotation.Rotate(touchObserver.inputRange);
            turretRotation.Shoote();
            yield return new WaitForFixedUpdate();
        }
    }
}