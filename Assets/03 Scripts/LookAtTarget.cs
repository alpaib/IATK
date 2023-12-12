using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target; // Referencia al objeto al que queremos mirar

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Obtener la dirección hacia el objetivo
            Vector3 targetDirection = transform.position - target.position;

            // Rotar para mirar hacia el objetivo
            transform.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        }
    }
}
