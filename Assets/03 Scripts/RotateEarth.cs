using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    public float rotationSpeed = 3.0f; // Velocidad de rotación

    // Update is called once per frame
    void Update()
    {
        // Rotar el objeto constantemente en el eje Y a la velocidad especificada
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
