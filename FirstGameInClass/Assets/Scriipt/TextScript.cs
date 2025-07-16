using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public TMP_Text scoreText; // Score display
    public GameObject go; // Assign the GameObject with ScoreScript in Inspector

    private int currentScore = 0;
    private ScoreScript scoreScript;

    void Start()
    {
        if (go != null)
        {
            scoreScript = go.GetComponent<ScoreScript>();
        }

    }

    void Update()
    {
        if (scoreScript != null)
        {
            int newScore = scoreScript.score; // Ensure 'score' is public in ScoreScript
            if (newScore != currentScore)
            {
                UpdateScore(newScore);
                currentScore = newScore ;
            }
        }
    }

   

    void UpdateScore(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }
}
