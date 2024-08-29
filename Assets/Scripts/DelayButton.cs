using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DelayButton : MonoBehaviour
{
    private Button myButton;
    public float delay = 2.0f;

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        myButton.interactable = false;
        StartCoroutine(EnableButtonAfterDelay());
    }

    IEnumerator EnableButtonAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        myButton.interactable = true;
    }
}
