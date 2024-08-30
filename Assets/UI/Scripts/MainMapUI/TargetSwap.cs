using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSwap : MonoBehaviour
{
    [SerializeField] Texture simpleTarget;
    [SerializeField] Texture greenTarget;
    [SerializeField] Texture redTarget;
    RawImage rawImage = null;
    [SerializeField] bool canBeSalvaged = false;
    [SerializeField] bool canbeDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponentInChildren();
        //Texture _texture= gameObject.TryGetComponent<Texture>;
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateBool(bool _value)
    {
        canBeSalvaged = _value;
        UpdateTexture();
    }
    void UpdateTexture()
    {
        rawImage.texture = canBeSalvaged ? greenTarget : canbeDestroyed? redTarget : simpleTarget;
    }
    public void UpdateDestroyedBool(bool _value)
    {
        canbeDestroyed = _value;
        UpdateTexture();
    }
}
