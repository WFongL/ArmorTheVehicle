using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turret;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float angleRange = 30;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float recharge;
    private float timeSleep;

    public void Reset()
    {
        var rotation = Quaternion.Euler(-90, 0, 0);
        turret.localRotation = rotation;
    }

    public void Rotate(float inputRange)
    {
        var rotation = Quaternion.Euler(-90, angleRange * inputRange, 0);
        turret.localRotation = rotation;
    }

    public void Shoote()
    {
        timeSleep -= Time.deltaTime;
        if (timeSleep > 0)
            return;

        Instantiate(bullet, muzzle.position, turret.rotation);
        timeSleep = recharge;
    }
}
