using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float lengthPlate = 31.5f;
    [SerializeField] private Transform target;
    private List<Transform> plates = new();
    private float step;

    private void Start()
    {
        foreach (Transform plate in transform)
            plates.Add(plate);

        step = lengthPlate * plates.Count;
    }

    public void Reset()
    {
        for (int i = 0; i < plates.Count; i++)
        {
            plates[i].position = new Vector3(0, 0, step / plates.Count * i);
        }
    }

    private void Update()
    {
        foreach (Transform plate in plates)
        {
            if (target.position.z > plate.position.z + lengthPlate)
            {
                plate.position = plate.position + new Vector3(0, 0, step);
            }
        }
    }
}
