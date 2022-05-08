using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetivo : MonoBehaviour
{
    [SerializeField] private float velocidadObjetivo = 0.5f;

    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * velocidadObjetivo;
    }
}
