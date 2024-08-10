using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void BackToMainmenu()
    {
        SceneManager.LoadScene("Mainmenu Scene");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
