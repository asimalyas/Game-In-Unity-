using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    private RectTransform rectComponent;
    private Image imageComp;
    private WinLossScript winLossScript;

    [Header("Reference to the player GameObject (with WinLossScript)")]
    public GameObject winLossObj;

    [Header("Duration to complete fill/drain (in seconds)")]
    [SerializeField] float durationInSeconds = 120f;

    private float speed;

    [SerializeField] float initialFillAmount = 0f;

    [Header("0 = Fill from 0 to 1, 1 = Drain from 1 to 0")]
    [SerializeField] int startingPoint = 0;

    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = initialFillAmount;

        // Calculate fill speed
        speed = 1f / durationInSeconds;

        // Get the WinLossScript component from the player object
        if (winLossObj != null)
        {
            winLossScript = winLossObj.GetComponent<WinLossScript>();
        }
        else
        {
            Debug.LogWarning("winLossObj is not assigned in the inspector!");
        }
    }

    void Update()
    {
        if (startingPoint == 0)
        {
            if (imageComp.fillAmount < 1f)
                imageComp.fillAmount += Time.deltaTime * speed;
            else
                imageComp.fillAmount = 0f;
        }
        else
        {
            if (imageComp.fillAmount > 0f)
                imageComp.fillAmount -= Time.deltaTime * speed;
            else
            {
                imageComp.fillAmount = 1f;

                if (winLossScript != null)
                {
                    winLossScript.lossGame();
                }
                else
                {
                    Debug.LogError("WinLossScript not found on winLossObj!");
                }
            }
        }
    }
}
