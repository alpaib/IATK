using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralControl : MonoBehaviour
{
    private GameObject MenuD1;
    public GameObject MenuD1_copy;

    // Update is called once per frame
    void Update()
    {
        MenuD1 = GameObject.FindGameObjectWithTag("MenuD1");

        if (OVRInput.GetDown(OVRInput.Button.One) && MenuD1 != null)
        {
            MenuD1.SetActive(false);
        }

        if (OVRInput.GetDown(OVRInput.Button.One) && MenuD1 == null)
        {
            MenuD1_copy.SetActive(true);
        }
    }
}
