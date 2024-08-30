using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBallon : MonoBehaviour
{
    [SerializeField] PlayerControler playerControler = null;
    [SerializeField] bool 
    //quand on rentre dans le ballon
    //
    //F�licitations!
    //Vous avez surv�cu!
    //Vous vous envolez vers des terres inconnues
    //
    //d�part du ballon
    //Timer
    //Endscreen (cr�dits)
    //
    //
    // Start is called before the first frame update
    void Start()
    {
        playerControler = GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        playerControler = other.GetComponent<PlayerControler>();
        if (!playerControler) return;

    }
    void Movement()
    {

    }
}
