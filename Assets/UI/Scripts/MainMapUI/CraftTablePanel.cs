using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftTablePanel : MonoBehaviour
{
    [SerializeField] GameObject craftPanel;
    [SerializeField] GameObject cursor;
    [SerializeField] TargetSwap reticleRef;
    [SerializeField] Detection_Item detectionRef;
    [SerializeField] PlayerControler playerRef;
    public Action<bool> OnPanelOpened = null;

    void Start()
    {
        

        OnPanelOpened += detectionRef.SetCanRotate;
        OnPanelOpened += playerRef.SetCanRotate;
        OnPanelOpened += playerRef.SetStopAttack;
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
        Cursor.visible = true;
        OnPanelOpened?.Invoke(false);

        Cursor.lockState = CursorLockMode.None;
    }
    private void OnTriggerExit(Collider other)
    {
        craftPanel.gameObject.SetActive(false);
        cursor.SetActive(true);
        reticleRef.gameObject.SetActive(true);
        Cursor.visible = false;
        OnPanelOpened?.Invoke(true);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
