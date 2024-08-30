using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBallon : MonoBehaviour
{
    [SerializeField] PlayerControler playerControler;
    [SerializeField] bool canFly = false;
    [SerializeField] float moveSpeed = 1.5f;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFly)
            Movement();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        playerControler = other.GetComponent<PlayerControler>();
        if (!playerControler) return;
        Invoke("SetCanFly", 3.0f);
    }
    void Movement()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    void SetCanFly()
    {
        canFly = true;
    }

}
