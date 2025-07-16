using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image targetImage;
    [SerializeField] private Color hoverColor = Color.yellow;

    private Color originalColor;

    void Start()
    {
        if (targetImage == null)
            targetImage = GetComponent<Image>();

        if (targetImage != null)
            originalColor = targetImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null)
            targetImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetImage != null)
            targetImage.color = originalColor;
    }
}
