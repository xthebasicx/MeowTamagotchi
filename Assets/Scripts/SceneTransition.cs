using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject SceneUI;
    public Animator transition;
    public GameObject TextObject;
    void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(1);
        SceneUI.SetActive(false);
    }
    public IEnumerator TransitionEnd(string Scene)
    {
        SceneUI.SetActive(true);
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Scene);
    }
    public IEnumerator TransitionDie(string Scene)
    {
        SceneUI.SetActive(true);
        TextObject.SetActive(true);
        transition.SetTrigger("End");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Scene);
    }


}
