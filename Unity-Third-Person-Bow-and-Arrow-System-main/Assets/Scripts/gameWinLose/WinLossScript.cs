using UnityEngine;

public class WinLossScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject lossPanel;
    public GameObject TimeLinePanel;
    public GameObject ScorePanel;
    public GameObject winPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lossGame()
    {
        Time.timeScale = 0;
        lossPanel.SetActive(true);
        TimeLinePanel.SetActive(false);
        ScorePanel.SetActive(false);

    }

    public void winGame()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        TimeLinePanel.SetActive(false);
        ScorePanel.SetActive(false);
    }
}
