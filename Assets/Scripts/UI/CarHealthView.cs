using UnityEngine;
using UnityEngine.UI;

public class CarHealthView : MonoBehaviour
{
    [SerializeField] private Car car;
    private Slider slider;

    private void Awake() => slider = GetComponent<Slider>();

    private void OnEnable() => car.ChangeHealth += UpdateSlider;

    private void OnDisable() => car.ChangeHealth -= UpdateSlider;

    private void UpdateSlider(float healht)
    {
        slider.value = healht;
    }
}
