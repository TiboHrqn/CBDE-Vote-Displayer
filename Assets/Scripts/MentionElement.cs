using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MentionElement : MonoBehaviour
{
    [SerializeField] private CanvasRenderer canvasRenderer;
    [SerializeField] private LayoutElement layoutElement;
    [SerializeField] private TMP_Text tmp;
    private int number;
    public int Number => number;
    private float durationOfLerp = 0.3f;

    void Start()
    {
        number = 0;
        UpdateUI(0, 0);
        gameObject.SetActive(false);
    }

    public void Increment()
    {
        UpdateUI(number, number + 1);
        number ++;
    }

    public void Decrement()
    {
        UpdateUI(number, number - 1);
        number --;
        if (number <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateUI(int from, int to)
    {
        tmp.text = to.ToString();
        StartCoroutine(LerpSize(from, to, durationOfLerp));
    }

    IEnumerator LerpSize(float startSize, float endSize, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);
            layoutElement.flexibleHeight = Mathf.Lerp(startSize, endSize, t);
            time += Time.deltaTime;
            yield return null;
        }
        layoutElement.flexibleHeight = endSize;
    }

}
