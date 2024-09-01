using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource objectDestructionSound;
    [SerializeField] AudioSource itemPickupSound;

    [SerializeField] DestructibleElement_Parent destructibleItem;

    void Start()
    {
        //destructibleItem = GetComponent<DestructibleElement_Parent>();

        destructibleItem.OnDestruction += DestructionSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestructionSound()
    {
        Debug.Log("BAMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");
    }
}
