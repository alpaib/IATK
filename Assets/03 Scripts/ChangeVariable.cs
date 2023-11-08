using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using IATK;

public class ChangeVariable : MonoBehaviour
{
    public GameObject iatkDataSet;
    public GameObject iatkVisualisation;

    [Header("Variables")]
    public string[] variableNames;

    private GameObject NewIatkVisualisation;

    private bool isIatkVisualisation;

    // Start is called before the first frame update
    void Start()
    {
        isIatkVisualisation = false;

        #region detect dataset variables

        if (iatkDataSet != null)
        {
            TextAsset csvData = iatkDataSet.GetComponent<CSVDataSource>().data;
            if (csvData != null)
            {
                string[] csvLines = csvData.text.Split('\n'); // Divide el TextAsset en líneas
                if (csvLines.Length > 0)
                {
                    string headerLine = csvLines[0].Trim(); // La primera línea contiene los nombres de las variables
                    variableNames = headerLine.Split(';'); // Divide la línea en función del punto y coma
                }
            }
            else
            {
                Debug.LogError("El TextAsset CSV no se ha asignado en el objeto CSVDataSource.");
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateIATK();

        AssignVariableX();
        AssignVariableY();
        AssignVariableZ();
    }

    public void InstantiateIATK()
    {
        //Instanciamos el visualizador de datos de IATK
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Z))
        {
            //Destruimos el visualizador IATK que haya
            if (NewIatkVisualisation != null)
            {
                Destroy(NewIatkVisualisation);
                Debug.Log("Objeto IATK destruido");
            }

            Instantiate(iatkVisualisation);
            Debug.Log("Objeto IATK creado");
            isIatkVisualisation = true;
        }

        //Lo asignamos a una nueva variable para poder completar sus datos
        if (NewIatkVisualisation == null && isIatkVisualisation)
        {
            NewIatkVisualisation = GameObject.FindGameObjectWithTag("NewIatkVisualisation");
            NewIatkVisualisation.GetComponent<Visualisation>().dataSource = iatkDataSet.GetComponent<CSVDataSource>();
            Debug.Log("Objeto IATK asignado");
        }
    }
    public void AssignVariableX()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
    }
    public void AssignVariableY()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {

        }
    }
    public void AssignVariableZ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }
}
