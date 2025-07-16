using UnityEngine;

public class BackgroundJangleSound : MonoBehaviour
{
    public AudioSource jungleAudio;
    public AudioClip jungleClip;

    void Start()
    {
        // Automatically get AudioSource if not assigned from Inspector
        if (jungleAudio == null)
            jungleAudio = GetComponent<AudioSource>();

        if (jungleAudio != null && jungleClip != null)
        {
            jungleAudio.clip = jungleClip;
            jungleAudio.loop = true; // Loop sound
            jungleAudio.Play();
        }
        else
        {
            Debug.LogWarning("Missing jungleAudio or jungleClip on " + gameObject.name);
        }
    }
}
