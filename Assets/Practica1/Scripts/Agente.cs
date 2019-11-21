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
        ConfiguracionFreno(d, freno,aFreno);

        transform.LookAt(destinoFinal);



        if (accionarFreno==false)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
        

    }

    protected void ConfiguracionFreno(Transform d,float f, bool aF)
    {
        aFreno2 = aF;
        float distancia = Vector3.Distance(transform.position, d.position);
        Debug.Log(distancia);

        if (distancia < f)
        {
            aF = true;
        }
       
    }
}
