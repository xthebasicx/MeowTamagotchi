using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
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
        scoreText.text = score.ToString() + "/10 ";
    }
    void EndGame()
    {
        if (score == 10)
        {
            SceneManager.LoadSceneAsync("Game Scene");
        }
    }
}
