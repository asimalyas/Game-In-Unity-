using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        // Load the next scene in the build settings (assumes the next scene is the main game)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();

//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
    }
}
