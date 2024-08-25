using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public Status status;
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectCat Scene");
        PlayerPrefs.DeleteAll();
        Status.isButtonPressed = false;

    }
    public void BackToMainmenu()
    {
        SceneManager.LoadScene("Mainmenu Scene");
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}