using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRulesScript : MonoBehaviour
{
    [SerializeField] GameObject rulesPanal;
    [SerializeField] GameObject loadpanal;
    int level = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pressOk()
    {

        SceneManager.LoadScene(this.level);
    }

    public void setLevel(int level)
    {
        loadpanal.SetActive(false);
        Debug.Log("load pnal fasle is called");
        rulesPanal.SetActive(true);
        this.level = level;
       
    }
}
