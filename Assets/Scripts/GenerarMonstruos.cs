using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarMonstruos : MonoBehaviour
{
    [SerializeField] private List<GameObject> listaMonstruos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Instantiate(listaMonstruos[1], new Vector3(0,0,-5), Quaternion.identity);
            Debug.Log("Hubo colisión");
        }
    }
}
