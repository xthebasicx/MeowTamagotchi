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
        ResetButtonState();
    }

    void OnButtonClick()
    {
        myButton.interactable = false;
        StartCoroutine(EnableButtonAfterDelay());
    }

    IEnumerator EnableButtonAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        if (gameObject.activeInHierarchy)
        {
            ResetButtonState();
        }
    }

    void ResetButtonState()
    {
        if (myButton != null)
        {
            myButton.interactable = true;
        }
    }
    void OnEnable()
    {
        ResetButtonState();
    }
    void OnDisable()
    {
        myButton.interactable = false;
    }
}
