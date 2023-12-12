using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Transform objectToRotate;
    public float rotationSpeed = 20.0f;
    public float targetRotation = 20.0f;

    private bool isRotating = false;

    void Start()
    {
        if (objectToRotate == null)
        {
            Debug.LogError("No se ha asignado ningún objeto para rotar.");
            enabled = false;
        }
    }

    public void RotateObjectByGesture()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateObjectSmoothly());
        }
    }

    IEnumerator RotateObjectSmoothly()
    {
        isRotating = true;

        float currentRotation = objectToRotate.rotation.eulerAngles.y;
        float destinationRotation = currentRotation + targetRotation;

        while (Mathf.Abs(objectToRotate.rotation.eulerAngles.y - destinationRotation) > 0.01f)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            objectToRotate.rotation = Quaternion.RotateTowards(objectToRotate.rotation, Quaternion.Euler(0, destinationRotation, 0), rotationStep);
            yield return null;
        }

        isRotating = false;
    }
}
