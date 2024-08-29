using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    [SerializeField] Animator zombieAnimator = null;

    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateAttackAnimatorParam(bool _value)
    {
        if (!zombieAnimator) return;
        zombieAnimator.SetBool(AnimatorParam.ZOMBIE_ATTACK_PARAM, _value);
    }
}
