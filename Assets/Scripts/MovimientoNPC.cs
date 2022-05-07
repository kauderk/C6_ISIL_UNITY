using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNPC : MonoBehaviour
{
    // -----    SEEK -------- //
    [SerializeField] private float velocidadMovimiento = 15;
#pragma warning disable CS0414 // Variable is assigned but its value is never used
    [SerializeField] private float velocidadRotacion = 3;
#pragma warning restore CS0414    // restore value not used warning
    [SerializeField] private Transform target;


    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, -velocidadMovimiento * Time.deltaTime);
        this.transform.LookAt(target.transform);
        this.transform.Rotate(0,180, 0);
    }
}
