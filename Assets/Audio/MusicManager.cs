using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    void Start()
    {
        AudioSource loopMusic = GetComponent<AudioSource>();      
        AudioSource timeElapsedMusic = GetComponent<AudioSource>();
        //loopMusic.DisableGamepadOutput();
        //gameObject.GetComponent<AudioSource>().Play(false);
    }


    void Update()
    {
        
    }
}
