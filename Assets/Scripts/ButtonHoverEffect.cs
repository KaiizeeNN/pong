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
            // Hedef alpha deðerine doðru geçiþ yap
            Color color = targetImage.color;
            color.a = Mathf.MoveTowards(color.a, targetAlpha, Time.deltaTime / fadeDuration);
            targetImage.color = color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fare butonun üzerine geldiðinde hedef alpha deðerini 1 yap
        targetAlpha = 1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Fare butondan çýktýðýnda hedef alpha deðerini 0 yap
        targetAlpha = 0f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Butona týklandýðýnda alpha deðerini sýfýrla
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