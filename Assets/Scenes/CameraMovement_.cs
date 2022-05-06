using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement_ : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento = 20f;

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = this.transform.right * x + this.transform.forward * z;
        this.transform.position += movimiento * velocidadMovimiento * Time.deltaTime;

    }
}
