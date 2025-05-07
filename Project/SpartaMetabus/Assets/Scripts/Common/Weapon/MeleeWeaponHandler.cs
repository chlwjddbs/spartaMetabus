using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponHandler : WeaponHandler
{
    [SerializeField] protected Collider2D attackCollider;


    public override void Init(IAttackHandler ownerStat, LayerMask targetMask)
    {
        base.Init(ownerStat, targetMask);
        attackCollider = GetComponent<Collider2D>();
        attackCollider.enabled = false;
    }

    public override void AttackAction()
    {
        base.AttackAction();
        attackCollider.enabled = true;
    }

    public void EndAttack()
    {
        attackCollider.enabled = false;
        targetList.Clear();
        //Debug.Log("EndAttack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((targetMask & (1 << collision.gameObject.layer)) != 0)
        {
            float damage = owner.AttackDamage + attackDamage;

            if (!targetList.Contains(collision.gameObject)) 
            {
                targetList.Add(collision.gameObject);
                collision.GetComponent<IDamageHandler>().TakeDamage(damage);
            }
        }
    }
}
