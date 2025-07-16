using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]  GameObject loadingPanel;  // Assign in Inspector
    [SerializeField] GameObject StagePanal;
    [SerializeField] GameObject gameRulesPanal;
    [SerializeField] GameRulesScript gameRulesScript;
    public void StartGame()
    {
        StagePanal.SetActive(true);
       
    }


    public void LoadLevel01()
    {
     
            loadingPanel.SetActive(true);
        StagePanal.SetActive(false);
        Invoke(nameof(LoadSceneLevel01), 5f);


    }

    private void LoadSceneLevel01()
    {
       
        gameRulesScript.setLevel(2);
    }

    public void LoadLevel02()
    {
        Debug.Log("button is pressed");
        loadingPanel.SetActive(true);
        StagePanal.SetActive(false);
        Invoke(nameof(LoadSceneLevel02), 5f);
    }

    private void LoadSceneLevel02()
    {
        Debug.Log("load level 02 is called");
        gameRulesScript.setLevel(3);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenSettings()
    {
        Debug.Log("Settings button clicked (not implemented yet)");
    }

    
}
