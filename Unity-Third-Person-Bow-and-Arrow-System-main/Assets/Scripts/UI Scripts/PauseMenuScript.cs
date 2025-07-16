using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] GameObject timeLinePanal;
    [SerializeField]  GameObject scorepanal;

    public void pause()
    {
        timeLinePanal.SetActive(false);
        scorepanal.SetActive(false);
        pauseMenu.SetActive(true);
   
    }

    public void resume()
    {
        timeLinePanal.SetActive(true);
        pauseMenu.SetActive(false);
        scorepanal.SetActive(true);
        
    }

    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void restart()
    {
       Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {
      
    }
}
