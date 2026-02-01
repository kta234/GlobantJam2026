using System.Diagnostics;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private AudioSource music;
    public AudioClip clickAudio;
    public AudioClip switchAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent <AudioSource>();
    }

    public void ClickAudioOn()
    {
        music.PlayOneShot(clickAudio);
    }
    public void SwitchAudioON()
    {
        music.PlayOneShot(switchAudio);
    }
}
