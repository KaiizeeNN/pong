using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image targetImage;
    public float fadeDuration = 0.5f;

    private bool isHovered = false;
    private float targetAlpha = 0f;

    void Start()
    {
        ResetAlpha();
    }

    void Update()
    {
        if (targetImage != null)
        {
            // Hedef alpha de�erine do�ru ge�i� yap
            Color color = targetImage.color;
            color.a = Mathf.MoveTowards(color.a, targetAlpha, Time.deltaTime / fadeDuration);
            targetImage.color = color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fare butonun �zerine geldi�inde hedef alpha de�erini 1 yap
        targetAlpha = 1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Fare butondan ��kt���nda hedef alpha de�erini 0 yap
        targetAlpha = 0f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Butona t�kland���nda alpha de�erini s�f�rla
        ResetAlpha();
    }

    private void ResetAlpha()
    {
        if (targetImage != null)
        {
            Color color = targetImage.color;
            color.a = 0f;
            targetImage.color = color;
            targetAlpha = 0f;
        }
    }
}