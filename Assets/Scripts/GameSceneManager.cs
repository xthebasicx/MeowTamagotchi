using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public void PlayGame()
    {
        ClearPlayerPrefs();
        Status.isButtonPressed = false;
        StartCoroutine(sceneTransition.TransitionEnd("SelectCat Scene"));

    }
    public void BackToMainmenu()
    {
        StartCoroutine(sceneTransition.TransitionEnd("Mainmenu Scene"));
    }
    public void Quit()
    {
        ClearPlayerPrefs();
        Debug.Log("Quit");
        Application.Quit();
    }
    private void ClearPlayerPrefs(){
        PlayerPrefs.DeleteKey("Health");
        PlayerPrefs.DeleteKey("Food");
        PlayerPrefs.DeleteKey("Shower");
        PlayerPrefs.DeleteKey("Mood");
        PlayerPrefs.DeleteKey("Stamina");
        PlayerPrefs.DeleteKey("Day");
        PlayerPrefs.DeleteKey("Cat");
        PlayerPrefs.DeleteKey("Evo");
    }
}