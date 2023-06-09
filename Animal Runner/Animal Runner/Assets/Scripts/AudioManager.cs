using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static List<GameObject> AudioManagers;

    private void Awake()
    {
        if (AudioManagers == null)
        {
            AudioManagers = new List<GameObject>();
            AudioManagers.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void KeepMusicPlaying()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void DestroyAudioManager()
    {
        AudioManagers = null;
        Destroy(gameObject);
    }

    public void ToggleBGM(bool audioPlaying)
    {
        if (audioPlaying)
        {
            GetComponent<AudioSource>().volume = 0.7f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0f;
        }
    }
}
