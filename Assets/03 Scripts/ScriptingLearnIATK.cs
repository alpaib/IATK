using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IATK;

public class ScriptingLearnIATK : MonoBehaviour
{

    public TextAsset dataFile;
    CSVDataSource dataSource;


    // Start is called before the first frame update
    void Start()
    {
        dataSource = createCSVDataSource(dataFile.text);    

        foreach (var dim in dataSource)
        {
            print(dim.Identifier);
        }

        Uber(dataSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    CSVDataSource createCSVDataSource(string data)
    {
        CSVDataSource dataSource = gameObject.AddComponent<CSVDataSource>();
        dataSource.load(data, null);
        return dataSource;
    }

    View Uber (CSVDataSource csvds)
    {
        // header
        // Date,Time,Lat,Lon,Base

        // Create gradient
        Gradient g = new Gradient();

        GradientColorKey[] gck = new GradientColorKey[2];
        gck[0] = new GradientColorKey(Color.blue, 0);
        gck[1] = new GradientColorKey(Color.red, 1);
        g.colorKeys = gck;

        // Create a view builder with the point topology
        ViewBuilder vb = new ViewBuilder(MeshTopology.Points, "Uber pick up point visualisation").
                             initialiseDataView(csvds.DataCount).
                             setDataDimension(csvds["Lat"].Data, ViewBuilder.VIEW_DIMENSION.X).
                             setDataDimension(csvds["Base"].Data, ViewBuilder.VIEW_DIMENSION.Y).
                             setDataDimension(csvds["Lon"].Data, ViewBuilder.VIEW_DIMENSION.Z);
                             //setSize(csvds["Base"].Data).
                             //setColors(csvds["Time"].Data.Select(x => g.Evaluate(x)).ToArray());

        // Use the "IATKUtil" class to get the corresponding Material mt 
        Material mt = IATKUtil.GetMaterialFromTopology(AbstractVisualisation.GeometryType.Points);
        mt.SetFloat("_MinSize", 0.01f);
        mt.SetFloat("_MaxSize", 0.05f);

        // Create a view builder with the point topology
        View view = vb.updateView().apply(gameObject, mt);
        return view;
    }
}
