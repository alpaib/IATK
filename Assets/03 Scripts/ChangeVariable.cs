using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IATK;

public class ChangeVariable : MonoBehaviour
{
    public GameObject iatkDataSet;
    public GameObject iatkVisualisation;
    private GameObject NewIatkVisualisation;

    private bool isIatkVisualisation;

    // Start is called before the first frame update
    void Start()
    {
        isIatkVisualisation = false;
    }

    // Update is called once per frame
    void Update()
    {    
        //Instanciamos el visualizador de datos de IATK
        if (Input.GetKeyDown(KeyCode.A))
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
}
