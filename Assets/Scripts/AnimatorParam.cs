using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParam
{
    public const string FORWARD_PARAM = "forward";
    public const string RIGHT_PARAM = "right";
    public const string SHOOT_PARAM = "shoot";
    public const string ZOMBIE_ATTACK_PARAM = "canAttack";
    //public const string SPEED_PARAM = "speed";

    //parametre de l'animator
    private static readonly int ForwardAxisParam = Animator.StringToHash(FORWARD_PARAM);
    private static readonly int RightAxisParam = Animator.StringToHash(RIGHT_PARAM);
    private static readonly int ZombieAttackParam = Animator.StringToHash(ZOMBIE_ATTACK_PARAM);
    //private static readonly int SpeedParam = Animator.StringToHash(SPEED_PARAM);
}
