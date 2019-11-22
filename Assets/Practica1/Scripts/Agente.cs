using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{
    [SerializeField]
    protected float velocidad;
    [SerializeField]
    protected Transform destino;
    [SerializeField]
    protected float freno;

    public bool aFreno;
    public bool aFreno2;

    protected void ConfigurarDestino(Transform d)
    {

        bool accionarFreno=aFreno;
        

        Vector3 destinoFinal = new Vector3(d.position.x, this.transform.position.y, d.position.z);
        ConfiguracionFreno(destinoFinal, freno,aFreno);

        transform.LookAt(destinoFinal);

        
       transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        
        

    }

    protected bool ConfiguracionFreno(Vector3 d,float f, bool aF)
    {
        float velocidadLocal = 1;
        float distancia = Vector3.Distance(transform.position, d);
        Debug.Log(distancia);

        if (distancia < f)
        {
            velocidad = 0;
            return (true);
        }
        else
        {
            velocidad = velocidadLocal;
            return (false);
        }
       
    }
}
