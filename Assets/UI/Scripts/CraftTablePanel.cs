using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTablePanel : MonoBehaviour
{
    [SerializeField] GameObject craftPanel;
    [SerializeField] GameObject cursor;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        craftPanel.gameObject.SetActive(true);
        cursor.SetActive(false);
        Debug.Log("marche");
    }
    private void OnTriggerExit(Collider other)
    {
        craftPanel.gameObject.SetActive(false);
        cursor.SetActive(true);
        Debug.Log("marche pô");
    }
}
