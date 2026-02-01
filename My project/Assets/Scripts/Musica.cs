using System;

using UnityEngine;

public class Musica : MonoBehaviour
{
    private AudioSource music;
    public AudioClip clickAudio;
    public AudioClip switchAudio;
    public AudioClip GameOverAudio;
    public AudioClip fondoAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent <AudioSource>();
        musicfondoOn();

    }

    public void ClickAudioOn()
    {
        music.PlayOneShot(clickAudio);
    }
    public void SwitchAudioON()
    {
        music.PlayOneShot(switchAudio);
    }
    public void musicfondoOn()
    {
        music.PlayOneShot(fondoAudio);
    }
    public void musicOff()
    {
        music.Stop();
    }
    public void GameOverAudioOn()
    {
        music.PlayOneShot(GameOverAudio);
        Debug.Log("sonido game over");
    }
}
