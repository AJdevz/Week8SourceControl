using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public TargetObject targetObject; // Reference to the target object's script
    private Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        if (targetObject != null)
        {
            healthText.text = targetObject.health.ToString("F0"); // Display health as an integer
            transform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position + Vector3.up); // Position the text above the object
        }
    }
}

