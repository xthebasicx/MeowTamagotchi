using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectCat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private float _moveTime = 0.1f;
    [Range(0f, 2f), SerializeField] private float _scaleAmount = 1.1f;


    private Vector3 _startScale;
    void Start()
    {
        _startScale = transform.localScale;
    }
    private IEnumerator MoveCard(bool startingAnimation)
    {

        Vector3 endScale;

        float elapsedTime = 0f;
        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;
            if (startingAnimation)
            {
                endScale = _startScale * _scaleAmount;
            }
            else
            {
                endScale = _startScale;
            }

            Vector3 lerpedScale = Vector3.Lerp(transform.localScale, endScale, (elapsedTime / _moveTime));

            transform.localScale = lerpedScale;
            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartCoroutine(MoveCard(true));
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartCoroutine(MoveCard(false));
    }
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
    public void Cat3()
    {
        PlayerPrefs.SetInt("Cat", 2);
        LoadScene();
    }
    private void LoadScene()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
