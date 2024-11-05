using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Public variables to set attack range, attack damage, attack interval, and movement speed
    public float attackRange = 1f;        // The range within which the AI will attack the target
    public float attackDamage = 10f;      // The amount of damage dealt on attack
    public float attackInterval = 1f;     // Time interval between each attack
    public float movementSpeed = 10f;     // The speed at which the AI moves towards the target
    private float nextAttackTime = 0f;    // Tracks the time until the next attack is allowed

    void Update()
    {
        // Find the target with the lowest health to attack
        TargetObject target = FindLowestHealthTarget();

        // If a valid target is found, perform movement and attack logic
        if (target != null)
        {
            // Move towards the target
            MoveTowards(target);

            // Check if the AI is within attack range and if enough time has passed since the last attack
            if (Vector3.Distance(transform.position, target.transform.position) < attackRange && Time.time >= nextAttackTime)
            {
                // Attack the target
                Attack(target);

                // Set the next allowed attack time based on the attack interval
                nextAttackTime = Time.time + attackInterval;
            }
        }
    }

    // Finds the target with the lowest health in the scene
    private TargetObject FindLowestHealthTarget()
    {
        // Get all objects of type TargetObject in the scene
        TargetObject[] targets = FindObjectsOfType<TargetObject>();
        
        // Initialize the lowest health target as null
        TargetObject lowestHealthTarget = null;

        // Iterate through all targets to find the one with the lowest health
        foreach (TargetObject target in targets)
        {
            // If no target has been assigned or this target has lower health, update the lowest health target
            if (lowestHealthTarget == null || target.health < lowestHealthTarget.health)
            {
                lowestHealthTarget = target;
            }
        }

        // Return the target with the lowest health (or null if none found)
        return lowestHealthTarget;
    }

    // Moves the AI towards the target using the movement speed
    private void MoveTowards(TargetObject target)
    {
        // Move the AI's position closer to the target's position
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
    }

    // Attacks the given target and applies damage
    private void Attack(TargetObject target)
    {
        // Call the TakeDamage method on the target with the specified attack damage
        target.TakeDamage(attackDamage);
    }
}


