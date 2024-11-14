using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Define the AI states
    private enum State { Idle, Chasing, Attacking }
    private State currentState = State.Chasing; // Start in the Chasing state

    // Public variables for AI configuration
    public float attackRange = 1f;
    public float attackDamage = 10f;
    public float attackInterval = 1f;
    public float movementSpeed = 10f;
    private float nextAttackTime = 0f;

    void Update()
    {
        // Toggle Idle state when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleIdleState();
        }

        // Only perform actions if not in the Idle state
        if (currentState != State.Idle)
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
    }

    // Toggle between Idle and Chasing/Attacking states
    private void ToggleIdleState()
    {
        if (currentState == State.Idle)
        {
            currentState = State.Chasing;
            Debug.Log("AI resumed chasing and attacking.");
        }
        else
        {
            currentState = State.Idle;
            Debug.Log("AI is now idle.");
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
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
    }

    private void Attack(TargetObject target)
    {
        target.TakeDamage(attackDamage);
    }
}
