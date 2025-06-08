using Newtonsoft.Json.Bson;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource current;
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
}
