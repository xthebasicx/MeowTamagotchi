using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectCat : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public void Cat1()
    {
        PlayerPrefs.SetInt("Cat", 0);
        LoadScene();
    }
    public void Cat2()
    {
        PlayerPrefs.SetInt("Cat", 1);
        LoadScene();
    }

    private void LoadScene()
    {
        StartCoroutine(sceneTransition.TransitionEnd("Game Scene"));
    }
}
