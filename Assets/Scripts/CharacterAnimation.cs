using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator characterAnimator = null;
    [SerializeField] float dampForward = .3f, dampRight = .3f;
    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateForwardAnimatorParam(float _value)
    {
        if (!characterAnimator) return;
        characterAnimator.SetFloat(AnimatorParam.FORWARD_PARAM, _value, dampForward, Time.deltaTime);
    }
    public void UpdateRightAnimatorParam(float _value)
    {
        if (!characterAnimator) return;
        characterAnimator.SetFloat(AnimatorParam.RIGHT_PARAM, _value, dampRight, Time.deltaTime);
    }
}
