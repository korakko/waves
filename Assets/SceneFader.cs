using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        // Start fully black and fade in
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float t = 1f;
        Color c = fadeImage.color;
        while (t > 0f)
        {
            t -= Time.deltaTime / fadeDuration;
            c.a = t;
            fadeImage.color = c;
            yield return null;
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;
        Color c = fadeImage.color;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            c.a = t;
            fadeImage.color = c;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator FadeOutCoroutine(string sceneName)
{
    float t = 0f;
    Color c = fadeImage.color;

    while (t < 1f)
    {
        t += Time.deltaTime / fadeDuration;
        c.a = t;
        fadeImage.color = c;
        yield return null;
    }

    SceneManager.LoadScene(sceneName);
}
}

