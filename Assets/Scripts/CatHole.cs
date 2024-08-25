using UnityEngine;
using UnityEngine.UI;

public class CatHole : MonoBehaviour
{
    public float minTimeToPop = 0.5f;
    public float maxTimeToPop = 2.0f;
    public float minTimeToHide = 0.5f;
    public float maxTimeToHide = 2.0f;

    private bool isPoppedUp = false;
    private Image CatImage;
    private Score score;

    void Start()
    {
        CatImage = GetComponent<Image>();
        CatImage.enabled = false;
        score = FindObjectOfType<Score>();
        Invoke("Show", Random.Range(minTimeToPop, maxTimeToPop));
    }

    void Show()
    {
        if (!isPoppedUp)
        {
            CatImage.enabled = true;
            isPoppedUp = true;
            Invoke("Hide", Random.Range(minTimeToHide, maxTimeToHide));
        }
    }

    void Hide()
    {
        CatImage.enabled = false;
        isPoppedUp = false;
        Invoke("Show", Random.Range(minTimeToPop, maxTimeToPop));
    }

    void OnMouseDown()
    {
        if (isPoppedUp)
        {
            CatImage.enabled = false;
            isPoppedUp = false;
            score.AddScore(1);
            CancelInvoke();
            Invoke("Show", Random.Range(minTimeToPop, maxTimeToPop));
        }
    }
}
