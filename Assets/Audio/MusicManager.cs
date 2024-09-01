using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource firstMainMusic;
    [SerializeField] AudioSource secondMainMusic;
    [SerializeField] AudioSource timeElapsedMusic;
    [SerializeField] AudioSource lostMusic;
    [SerializeField] AudioSource winMusic;
    [SerializeField] bool canStartWinMusic = false;
    [SerializeField] bool canStartLostMusic = false;
    public event Action OnBool = null;


    void Start()
    {
        //firstMainMusic = GetComponent<AudioSource>(); 
        //secondMainMusic = GetComponent<AudioSource>();
        //timeElapsedMusic = GetComponent<AudioSource>();
        //lostMusic = GetComponent<AudioSource>();
        //winMusic = GetComponent<AudioSource>();

        //firstMainMusic.Play();

        firstMainMusic.PlayDelayed(6);
        OnBool += OnWin;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayTimeElapsedMusic()
    {
        firstMainMusic.Stop();
        secondMainMusic.Stop();
        timeElapsedMusic.Play();

    }
    public void UpdateWinBool(bool _value)
    {
        canStartWinMusic = _value;
        //OnBool?.Invoke();
        
    }
    public void UpdateLostBool(bool _value)
    {
        canStartLostMusic= _value;              
        OnLoose();
        
    }
    public void OnWin()
    {        
        firstMainMusic.Stop();
        secondMainMusic.Stop();
        timeElapsedMusic.Stop();
        winMusic.Play();
    }
    public void OnLoose()
    {
        firstMainMusic.Stop();
        secondMainMusic.Stop();
        timeElapsedMusic.Stop();
        winMusic.Stop();
        lostMusic.Play();
        //test
    }
    void PlayMusic()
    {        
        winMusic.Stop();
        timeElapsedMusic.Stop();
        secondMainMusic.Play();
    }
}
