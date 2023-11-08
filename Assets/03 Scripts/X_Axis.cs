using UnityEngine;
using IATK; // Asegúrate de importar el espacio de nombres correcto

public class X_Axis : MonoBehaviour
{
    public Visualisation visualisation; // Asigna la visualización que deseas modificar desde el Inspector de Unity
    public float changeInterval = 2.0f; // Intervalo de cambio en segundos

    private float timer = 0.0f;
    private int currentColumn = 0;

    private void Start()
    {
        if (visualisation != null && visualisation.dataSource != null && visualisation.dataSource.IsLoaded)
        {
            ChangeXAxisToNextColumn();
        }
    }

    private void Update()
    {
        // Comprueba si el intervalo de tiempo ha pasado y cambia el eje X
        if (timer >= changeInterval)
        {
            ChangeXAxisToNextColumn();
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }

    // Esta función cambia el eje X a la siguiente columna de datos en el CSV
    private void ChangeXAxisToNextColumn()
    {
        if (visualisation != null && visualisation.dataSource != null && visualisation.dataSource.IsLoaded)
        {
            int columnCount = visualisation.dataSource.DimensionCount;

            if (columnCount > 0)
            {
                currentColumn = (currentColumn + 1) % columnCount;
                visualisation.xDimension.Attribute = visualisation.dataSource[currentColumn].Identifier;
                visualisation.updateView(AbstractVisualisation.PropertyType.X);
            }
        }
    }
}