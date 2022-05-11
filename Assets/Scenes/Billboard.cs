using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera Camera;

    void Start() => Camera = Camera.main;

    void Update() => transform.LookAt(Camera.transform);

}
