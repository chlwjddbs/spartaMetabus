using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponStateMachineBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.TryGetComponent<MeleeWeaponHandler>(out MeleeWeaponHandler weapon))
        {
            weapon.EndAttack();
        }
    }
}
