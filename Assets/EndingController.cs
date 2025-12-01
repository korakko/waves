using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public TMP_Text creditText;
    public string[] creditLines;
    public float delay = 3f;
    public Image endingImage;
    public Sprite[] endingSprites;

    void Start()
    {
        StartCoroutine(PlayEnding());
    }

    private System.Collections.IEnumerator PlayEnding()
    {
        // SHOW TEXT ONE BY ONE
        foreach (string line in creditLines)
        {
            creditText.text = line;
            yield return new WaitForSeconds(delay);
        }

        // OPTIONAL – SHOW FINAL IMAGES
        //foreach (var sprite in endingSprites)
        //{
            //endingImage.sprite = sprite;
            //endingImage.gameObject.SetActive(true);
            //yield return new WaitForSeconds(3f);
            //endingImage.gameObject.SetActive(false);
        //}
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("waves");
    }
}
