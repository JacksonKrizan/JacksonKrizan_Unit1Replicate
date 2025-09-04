using UnityEngine;
using UnityEngine.UI;

public class FloatingFadeUI : MonoBehaviour
{
    private float floatDistance = 300f; // How far to float upwards (in UI units)
    private float duration = 20f;      // How long the effect lasts
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPos;
    private float timer;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        startPos = rectTransform.anchoredPosition;
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);
        // Move up
        rectTransform.anchoredPosition = startPos + Vector2.up * floatDistance * t;
        // Fade out
        canvasGroup.alpha = 1f - t;
        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
