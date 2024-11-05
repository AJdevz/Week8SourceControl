using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float attackRange = 1f;
    public float attackDamage = 10f;
    public float attackInterval = 1f;
    public float movementSpeed = 10f; 
    private float nextAttackTime = 0f;

    void Update()
    {
        TargetObject target = FindLowestHealthTarget();
        if (target != null)
        {
            MoveTowards(target);
            if (Vector3.Distance(transform.position, target.transform.position) < attackRange && Time.time >= nextAttackTime)
            {
                Attack(target);
                nextAttackTime = Time.time + attackInterval;
            }
        }
    }

    private TargetObject FindLowestHealthTarget()
    {
        TargetObject[] targets = FindObjectsOfType<TargetObject>();
        TargetObject lowestHealthTarget = null;

        foreach (TargetObject target in targets)
        {
            if (lowestHealthTarget == null || target.health < lowestHealthTarget.health)
            {
                lowestHealthTarget = target;
            }
        }

        return lowestHealthTarget;
    }

private void MoveTowards(TargetObject target)
{
    // Move towards the target using the movement speed variable
    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
}


    private void Attack(TargetObject target)
    {
        target.TakeDamage(attackDamage);
    }
}


