using UnityEngine;

public class CatHole : MonoBehaviour
{
    public float appearTime = 1.0f;
    private bool isVisible = false;
    private float timer = 0f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= appearTime)
        {
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;
            timer = 0f;
        }

        if (isVisible && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                Hit();
            }
        }
    }

    void Hit()
    {
        Debug.Log("Hit!");
        isVisible = false;
        spriteRenderer.enabled = false;
    }
}
