using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip wrongClip;
    [SerializeField] AudioClip correctClip;
    [SerializeField] AudioClip musicClip;

    [SerializeField] [Range(0f, 1f)] float wrongVolume;
    [SerializeField] [Range(0f, 1f)] float correctVolume;
    [SerializeField] [Range(0f, 1f)] float musicVolume;

    static AudioPlayer instance;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

    public void PlayWrongClip()
    {
        PlayClip(wrongClip, wrongVolume);
    }

    public void PlayRightClip()
    {
        PlayClip(correctClip, correctVolume);
    }

    public void PlayMusicClip()
    {
        PlayClip(musicClip, musicVolume);
    }
}
