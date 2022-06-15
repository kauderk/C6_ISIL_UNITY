using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{
    private Transform target;
    public bool billboardEnabled = true;

    void Awake()
    {
        // find a vaild target
        target = GameObject.FindGameObjectWithTag("Player").transform ?? Camera.main.transform;
    }

    void Update()
    {
        if (billboardEnabled)
            transform.LookAt(target);
        else
            transform.rotation = target.transform.rotation;

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

}
