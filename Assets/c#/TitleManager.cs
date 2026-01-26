using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TitleManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 1.0f;

    public void StartGame()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    IEnumerator FadeOutAndLoad()
    {
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            color.a = t / fadeTime;
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene("SceneGame");
        // ‚à‚µ‚­‚Í SceneManager.LoadScene(1);
    }
}
