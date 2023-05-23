using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private float alpha;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        alpha = 1f;
    }

    public void Hide()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {

        while (alpha > 0f) 
        {
            alpha -= 0.03f;
            float a = curve.Evaluate(alpha);
            img.color = new Color(0f, 0f, 0f, a);
            yield return new WaitForSeconds(0.03f); 
        }

        gameObject.SetActive(false);
    }
}
