using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance;
    private WinLossScript winLossScript;

    [Header("Reference to the player GameObject (with WinLossScript)")]
    public GameObject winLossObj;
    private int score = 0;
    private float arrowcount;
    [SerializeField] TextMeshProUGUI scoreText;
   [SerializeField] TextMeshProUGUI arrowCountText;
    private void Start()
    {
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
    void Awake()
    {
        // Setup Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
        // Optional: update UI here
        if (scoreText != null)
            scoreText.text = score.ToString();
        if (score >= 100)
        {
            winLossScript.winGame();
        }
    }
    public void ArowDetails(float no)
    {
        arrowcount = no;
        Debug.Log(arrowcount);
        if (arrowCountText != null)
            arrowCountText.text = arrowcount.ToString();

    }
    public int GetScore()
    {
        return score;
    }
}
