using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource loopMusic = null;
    [SerializeField] AudioSource timeElapsedMusic = null;
    [SerializeField] AudioSource lostMusic = null;
    [SerializeField] AudioSource winMusic = null;
    [SerializeField] bool canStartWinMusic = false;
    [SerializeField] bool canStartLostMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        loopMusic = GetComponent<AudioSource>();      
        timeElapsedMusic = GetComponent<AudioSource>();
        lostMusic = GetComponent<AudioSource>();
        winMusic = GetComponent<AudioSource>();

        loopMusic.Play();
        Invoke("PlayMusic", 367);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayTimeElapsedMusic()
    {
        loopMusic.Stop();
        timeElapsedMusic.Play();

    }
    public void UpdateWinBool(bool _value)
    {
        canStartWinMusic = _value;
    }
    public void UpdateLostBool(bool _value)
    {
        canStartLostMusic= _value;
    }
    void OnWin()
    {
        loopMusic.Stop();
        timeElapsedMusic.Stop();
        winMusic.Play();
    }
    void OnLoose()
    {
        loopMusic.Stop();
        timeElapsedMusic.Stop();
        winMusic.Stop();
        lostMusic.Play();
    }
}
