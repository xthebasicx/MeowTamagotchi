using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public SceneTransition sceneTransition;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }
    void Update()
    {
        EndGame();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString() + "/5";
    }
    void EndGame()
    {
        if (score == 5)
        {
            StartCoroutine(sceneTransition.TransitionEnd("Game Scene"));
        }
    }
}
