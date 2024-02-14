using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderPassing : MonoBehaviour
{
    [SerializeField] private float timePassing;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;
    private float time;

    public event Action Win;

    public void StartPassing() => StartCoroutine(Passing());

    public void StopPassing() => StopAllCoroutines();

    public void Reset()
    {
        time = 0;
        TextUpdate();
        SliderUpdate();
    }

    private IEnumerator Passing()
    {
        while (time < timePassing)
        {
            time += Time.deltaTime;
            SliderUpdate();
            TextUpdate();
            yield return new WaitForEndOfFrame();
        }
        Win?.Invoke();
    }

    private void TextUpdate() => text.text = ((int)time * 10).ToString();

    private void SliderUpdate() => slider.value = time / timePassing;
}
