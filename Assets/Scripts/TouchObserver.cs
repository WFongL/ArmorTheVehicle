using UnityEngine;
using UnityEngine.EventSystems;

public class TouchObserver : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform turret;
    [SerializeField] private float angleRange = 30;
    public float inputRange {  get; private set; }
    private float center;

    private void Start()
    {
        center = Screen.width / 2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        inputRange = (eventData.position.x - center) / center;
        var rotation = Quaternion.Euler(-90, angleRange * inputRange, 0);
        turret.localRotation = rotation;
    }
}
