using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIMover : MonoBehaviour
{
    private float fadeSpeed = 1.25f;
    private float moveSpeed = 50.0f;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, Time.deltaTime * fadeSpeed);
        transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);

        if (canvasGroup.alpha < 0.01f)
            Destroy(gameObject);
    }
}
