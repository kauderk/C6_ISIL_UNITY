using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{
    private Transform target;

    void Awake()
    {
        // find a vaild target
        target = GameObject.FindGameObjectWithTag("Player").transform ?? Camera.main.transform;
    }

    void Update() => transform.LookAt(target.transform);

}
