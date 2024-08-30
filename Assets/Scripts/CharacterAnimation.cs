using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    [SerializeField] Animator characterAnimator = null;
    [SerializeField] float dampForward = .3f, dampRight = .3f;
    
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void UpdateForwardAnimatorParam(float _value)
    {
        
        if (!characterAnimator) return;
        Debug.Log(_value);
        characterAnimator.SetFloat(AnimatorParam.FORWARD_PARAM, _value, dampForward, Time.deltaTime);
    }
    public void UpdateRightAnimatorParam(float _value)
    {
        if (!characterAnimator) return;
        characterAnimator.SetFloat(AnimatorParam.RIGHT_PARAM, _value, dampRight, Time.deltaTime);
    }

    public void UpdateRunAnimatorParam(bool _value)
    {
        Debug.Log("courrir à fond");
        if (!characterAnimator) return;
        characterAnimator.SetBool(AnimatorParam.RUN_PARAM, _value);
    }

    public void ShootAnimatorParam()
    {
        if (!characterAnimator) return;
        characterAnimator.SetTrigger(AnimatorParam.SHOOT_PARAM);
    }

    public void DeathAnimatorParam(bool _value)
    {
        if (!characterAnimator) return;
        characterAnimator.SetBool(AnimatorParam.DEATH_PARAM, _value);
    }

}
