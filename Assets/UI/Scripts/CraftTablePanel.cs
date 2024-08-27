using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTablePanel : MonoBehaviour
{   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
