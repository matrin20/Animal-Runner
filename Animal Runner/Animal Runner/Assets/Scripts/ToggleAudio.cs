using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{

    public static bool AudioPlaying = true;
    [SerializeField]
    private GameObject disabledIcon;
    private PlayerData _playerData;

    private void Start()
    {
        disabledIcon.SetActive(false);
        _playerData = GameObject.Find("PlayerDataDDOL").GetComponent<PlayerData>();
        AudioPlaying = _playerData.GetAudioState();
        if (AudioPlaying == false)
        {
            disabledIcon.SetActive(!AudioPlaying);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().ToggleBGM(AudioPlaying);
        }

    }

    public void ToggleMusic()
    {
        AudioPlaying = !AudioPlaying;
        disabledIcon.SetActive(!AudioPlaying);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().ToggleBGM(AudioPlaying);
        _playerData.SetAudioState(AudioPlaying);

    }
}
