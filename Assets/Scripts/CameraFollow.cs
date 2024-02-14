using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothMove = 0.4f;
    [SerializeField] private float smoothRotate = 0.4f;
    [SerializeField] private Offset offsetCar;
    [SerializeField] private Offset garageOffset;
    private Offset offsetState;

    private void Awake() => ToGarage();

    public void ToGarage()
    {
        offsetState = garageOffset;
        transform.position = offsetState.position;
        transform.rotation = Quaternion.Euler(offsetState.rotation);
    }

    public void ToCarMove() => offsetState = offsetCar;

    void FixedUpdate()
    {
        var desiredPosition = target.position + offsetState.position;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothMove * Time.fixedDeltaTime);
        transform.position = smoothedPosition;

        Vector3 rotation = transform.rotation.eulerAngles;
        var smoothedRotation = Vector3.Lerp(rotation, offsetState.rotation, smoothRotate * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(smoothedRotation);
    }
}

[Serializable]
public class Offset
{
    public Vector3 position;
    public Vector3 rotation;
}
