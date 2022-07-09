using UnityEngine;

public class NavMeshCubePlacer : MonoBehaviour
{
    private NavMeshGrid grid;

    private void Awake()
    {
        grid = FindObjectOfType<NavMeshGrid>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        var primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        primitive.transform.position = finalPosition;
        PointEvents.OnPointCreated?.Invoke(primitive);

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = clickPoint;
    }
}