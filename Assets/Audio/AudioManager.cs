using Newtonsoft.Json.Bson;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource current;
    private bool isPaused = false;
    void Start()
    {
        current.Play();
    }

   
    void Update()
    {
        
    }
    public void ChangeMusic(AudioClip music)
    {
        current.Stop();
        current.clip = music;
        current.Play();
    }

    public void StopMusic()
    {
        if (isPaused)
        {
            current.Play();
            isPaused = false;
        }
        else
        {
            current.Pause();
            isPaused = true;
        }

    }

}
