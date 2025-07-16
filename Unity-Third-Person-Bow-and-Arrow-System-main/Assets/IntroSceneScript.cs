using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroSceneScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // When video finishes, call OnVideoEnd
        videoPlayer.loopPointReached += OnVideoEnd;

    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

   public void SkipVideo()
    {
        videoPlayer.Stop();
        LoadNextScene();
    }

    void LoadNextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
