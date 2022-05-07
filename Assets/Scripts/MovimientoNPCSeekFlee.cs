using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNPCSeekFlee : MonoBehaviour
{
    public enum TipoMovimiento {seek, flee, pursuit, evasion, arrival, wander, pathFollowing}
    [Header("Tipo de Movimiento")]
    public TipoMovimiento tipoMovimiento;

    [Header("Valores Numéricos")]
    [SerializeField] private float fuerzaMasa = 15;
    [SerializeField] private float velocidadMovimiento = 15;
    [SerializeField] private float velocidadRotacion = 3;
    [SerializeField] private Transform target;
    private Vector3 vectorVelocidad;

    [SerializeField] private float factorPrediccion = 0.5f;
    private Vector3 posicionFuturaObjetivo;

    [SerializeField] private float factorReduccion = 0.5f;
   
    //----Wander
    [SerializeField] private float radioMinCirculo = 1f;
    [SerializeField] private float radioMaxCirculo = 5f;
    [SerializeField] private float oportunidadGiro = 0.1f;
    private Vector3 posicionDeambular;

    //----Path Following
    private List<Vector3> listaPuntos;
    [SerializeField] private float distanciaPunto = 5f;
    private int indice;

    void Start()
    {
        vectorVelocidad = Vector3.zero;
        posicionFuturaObjetivo = Vector3.zero;

        posicionDeambular = FuerzaAleatoriaDeambular();

        listaPuntos = new List<Vector3>();
        listaPuntos.Add(new Vector3(0,0,0));
        listaPuntos.Add(new Vector3(5,0,5));
        listaPuntos.Add(new Vector3(10,0,10));
        listaPuntos.Add(new Vector3(15,0,15));

        indice = 0;
    }


    void Update()
    {
        switch( (int) tipoMovimiento)
        {
            case 0: Seek(); break;
            case 1: Flee(); break;
            case 2: Pursuit(); break;
            case 3: Evasion(); break;
            case 4: Arrival(); break;
            case 5: Wander(); break;
            case 6: PathFollowing(); break;
        }
    }


    private void Seek()
    {
        var velocidadDeseada = target.transform.position - this.transform.position;
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);
    }

    private void Flee()
    {
        var velocidadDeseada = target.transform.position - this.transform.position;
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += -vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);

        this.transform.Rotate(0,180,0);
    }

    private void Pursuit()
    {

        posicionFuturaObjetivo = target.transform.position + (target.GetComponent<Rigidbody>().velocity * factorPrediccion);

        var velocidadDeseada = posicionFuturaObjetivo - this.transform.position;
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);
    }

    private void Evasion()
    {
        posicionFuturaObjetivo = target.transform.position + (target.GetComponent<Rigidbody>().velocity * factorPrediccion);

        var velocidadDeseada = this.transform.position - posicionFuturaObjetivo;
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);
    }

    private void Arrival()
    {
        var velocidadDeseada = target.transform.position - this.transform.position;
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        float distancia = velocidadDeseada.magnitude;
        float velocidadDisminucion = velocidadMovimiento * (distancia/factorReduccion);
        float velocidadFinal = Mathf.Min(velocidadDisminucion, velocidadMovimiento);

        velocidadDeseada = (velocidadDisminucion / distancia) * (target.transform.position - this.transform.position);

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);
    }

    private void Wander()
    {

        var velocidadDeseada = FuerzaDeambular();
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);
    }

    private void PathFollowing()
    {
        if((listaPuntos[indice] - this.transform.position).magnitude < distanciaPunto)
        {
            indice++;
            if(indice == listaPuntos.Count)
            {
                indice = 0;
            } 
            target.transform.position = listaPuntos[indice];
        }

        var velocidadDeseada = target.transform.position - this.transform.position;
        velocidadDeseada = velocidadDeseada.normalized * velocidadMovimiento;

        var direccion = velocidadDeseada - vectorVelocidad;
        direccion = Vector3.ClampMagnitude(direccion, velocidadRotacion);
        direccion /= fuerzaMasa;        

        vectorVelocidad = Vector3.ClampMagnitude(vectorVelocidad+direccion, velocidadMovimiento);

        this.transform.position += vectorVelocidad * Time.deltaTime;
        this.transform.forward = vectorVelocidad.normalized; 

        Debug.DrawRay(this.transform.position, vectorVelocidad.normalized * 10, Color.green);
        Debug.DrawRay(this.transform.position, velocidadDeseada.normalized * 15, Color.black);
    }

    private Vector3 FuerzaDeambular()
    {
        if(this.transform.position.magnitude > radioMaxCirculo)
        {
            var apuntarCentro = (target.transform.position - this.transform.position).normalized;
            posicionDeambular = vectorVelocidad.normalized + apuntarCentro;
        }
        else if(Random.value < oportunidadGiro)
        {
            posicionDeambular = FuerzaAleatoriaDeambular();
        }
        return posicionDeambular;   
    }

    private Vector3 FuerzaAleatoriaDeambular()
    {
        var centroCirculo = vectorVelocidad.normalized;
        var randomPoint = Random.insideUnitCircle;

        var desplazamiento = new Vector3(randomPoint.y, 0) * radioMinCirculo;
        var posicionAleatorioDeambular = centroCirculo + desplazamiento;
        return posicionAleatorioDeambular;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("chocamos");
            Destroy(gameObject);
        }
    }
}
