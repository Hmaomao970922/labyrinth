using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip bomb;
    public AudioClip coin;

    private AudioSource player;
    void Awake()
    {
        Instance = this;
        player = GetComponent<AudioSource>();
    }
    
    public void PlayBomb()
    {
        player.PlayOneShot(bomb);
    }
    public void PlayCoin()
    {
        player.PlayOneShot(coin);
    }
}
