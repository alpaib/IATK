using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject globalIPInfoCanvas;
    public GameObject InternetAcessCanvas;

    public GameObject[] connections;
    public GameObject[] connectionsInfo;

    private bool isGlobalIPInfo;
    private bool isInternetAccess;
    private bool isConnection;
    private bool isConnectionInfo;

    private void Start()
    {
        isGlobalIPInfo = false;
        isInternetAccess = false;
        isConnectionInfo = false;
        isConnectionInfo = false;

        //buscar información de las conexiones y apagar
        connectionsInfo = GameObject.FindGameObjectsWithTag("ConnectionInfo");
        for (int i = 0; i < connectionsInfo.Length; i++)
        {
            connectionsInfo[i].SetActive(false);
        }

        //buscar conexiones y apagar
        connections = GameObject.FindGameObjectsWithTag("Connection");
        for (int i = 0; i < connections.Length; i++)
        {
            connections[i].SetActive(false);
        }
    }
    public void GlobalIPInfo()
    {
        if (isGlobalIPInfo)
        {
            globalIPInfoCanvas.SetActive(false);
            isGlobalIPInfo = false;
        }
        
        else
        {
            globalIPInfoCanvas.SetActive(true);
            isGlobalIPInfo = true;
        }
    }

    public void InternetAccess()
    {
        if (isInternetAccess)
        {
            InternetAcessCanvas.SetActive(false);
            isInternetAccess = false;
        }

        else
        {
            InternetAcessCanvas.SetActive(true);
            isInternetAccess = true;
        }
    }

    public void Connections()
    {
        if (isConnection)
        {
            for (int i = 0; i < connections.Length; i++)
            {
                connectionsInfo[i].SetActive(false);
                connections[i].SetActive(false);
            }
            isConnection = false;
        }

        else
        {
            for (int i = 0; i < connections.Length; i++)
            {
                connections[i].SetActive(true);
            }

            isConnection = true;
        }
    }

    public void ConnectionsInfo()
    {
        if (isConnection && !isConnectionInfo)
        {
            for (int i = 0; i < connectionsInfo.Length; i++)
            {
                connectionsInfo[i].SetActive(true);
            }
            isConnectionInfo = true;
        }

        else
        {
            for (int i = 0; i < connectionsInfo.Length; i++)
            {
                connectionsInfo[i].SetActive(false);
            }

            isConnectionInfo = false;
        }
    }
}
