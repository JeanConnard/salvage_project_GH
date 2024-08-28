using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTablePanel : MonoBehaviour
{
    [SerializeField] GameObject craftPanel;
    [SerializeField] GameObject cursor;
    [SerializeField] TargetSwap reticleRef;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerControler _target = other.GetComponent<PlayerControler>();
        if (!_target) return;
        craftPanel.gameObject.SetActive(true);
        cursor.SetActive(false);
        reticleRef.gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        craftPanel.gameObject.SetActive(false);
        cursor.SetActive(true);
        reticleRef.gameObject.SetActive(true);
    }
}
