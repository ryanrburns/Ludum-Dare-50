using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        audioPlayer.PlayMusicClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
