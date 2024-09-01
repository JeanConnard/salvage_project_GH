using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource loopMusic = GetComponent<AudioSource>();      
        AudioSource timeElapsedMusic = GetComponent<AudioSource>();
        //loopMusic.DisableGamepadOutput();
        //gameObject.GetComponent<AudioSource>().Play(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
