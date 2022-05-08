using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrices : MonoBehaviour
{
    int filas;
    int columnas;
    int [,] matriz;
    //int[,,] matriz = new int[4, 2, 3];


    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        // frame 0
        filas = 2;
        columnas = 2;

        matriz = new int[filas, columnas];

        //declarar objetos
        matriz[0,0] = 1;
        matriz[0,1] = 2;
        matriz[1,0] = 3;
        matriz[1,1] = 4;

        Debug.Log("Frame Start");
        // frame 1
        // funcion se ejecuta solo una vez

        List<string> nombrePersonas1 = new List<string> { "nombre1", "nombre2", "nombre3", "nombre4" };
        List<string> nombrePersonas2 = new List<string> { "nombre5", "nombre6", "nombre7", "nombre8" };
        List<string> nombrePersonas3 = new List<string> { "nombre9", "nombre10", "nombre11", "nombre12" };

        Debug.Log(nombrePersonas1[3]);

        List<float> precioProducto = new List<float>();
        precioProducto.Add(17.5f);
        precioProducto.Add(14.8f);
        precioProducto.Add(11.3f);
        precioProducto.Add(4.9f);
        precioProducto.RemoveAt(1);
        Debug.Log(precioProducto[2]);

        List<int> numeroGanador = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int valorGanador = Random.Range(numeroGanador[0], numeroGanador[numeroGanador.Count - 1]);
        Debug.Log("Valor ganador es: " + valorGanador);

        
        List<List<string>> listaDeListas = new List<List<string>>();
        listaDeListas.Add(nombrePersonas1);
        listaDeListas.Add(nombrePersonas2);
        listaDeListas.Add(nombrePersonas3);

        Debug.Log(listaDeListas[2][3]);

    }

    // Update is called once per frame
    void Update()
    {
        // [0]  [0,1,2]
        // [1]  [3,4,5]
        // [2]  [6,7,8]

        

        // Matrices estáticas: asignar un espacio en memoria antes de ejecución
        // Matrices dinámicas: asignar espacio en memoria en tiempo de ejecución

        // funcion se ejecutan hasta el fin de la aplicacion
        // movimiento personaje
    }

    void FixedUpdate()
    {
        // movimiento camara
    }

    void LateUpdate()
    {
        
    }
}
