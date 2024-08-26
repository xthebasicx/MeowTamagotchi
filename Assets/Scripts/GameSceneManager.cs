using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        Status.isButtonPressed = false;
        StartCoroutine(sceneTransition.TransitionEnd("SelectCat Scene"));

    }
    public void BackToMainmenu()
    {
        StartCoroutine(sceneTransition.TransitionEnd("Mainmenu Scene"));
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}