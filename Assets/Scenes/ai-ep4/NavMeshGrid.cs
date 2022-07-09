using UnityEngine;

public class NavMeshGrid : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 5.0f)]
    private float size = 1f;

    [SerializeField]
    private float drawSize = 1f;

    [SerializeField]
    [Range(10, 40)]
    private int units = 35;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (float x = 0; x < units; x += size)
        {
            for (float z = 0; z < units; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, drawSize);
            }

        }
    }
}