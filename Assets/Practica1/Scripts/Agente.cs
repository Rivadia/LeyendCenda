using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{

    private float velocidad;
    [SerializeField]
    protected Transform destino;
    [SerializeField]
    protected float freno;
    [SerializeField]
    protected float distanciaMeta;

    [SerializeField]
   protected Transform objetivo;



    [SerializeField]
    protected float VelocidadAgente{

        get{
            return velocidad;  
           }
        set
        {
            this.velocidad = value;
        } 

      }



    protected void ConfigurarDestino(Transform d)
    {

  
        

        Vector3 destinoFinal = new Vector3(d.position.x, this.transform.position.y, d.position.z);
        ConfiguracionFreno(destinoFinal, freno);

        transform.LookAt(destinoFinal); 
       transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        
        

    }

    protected bool ConfiguracionFreno(Vector3 d,float f)
    {
        float velocidadLocal = 1;
        float distancia = Vector3.Distance(transform.position, d);
    

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

    protected float MedirDistancia()
    {
        Vector3 metaPos = new Vector3(objetivo.position.x, this.transform.position.y, objetivo.position.z);
        float distancia = Vector3.Distance(transform.position, metaPos);
        Debug.Log(distancia);
        return distancia; 
               
    }

    protected bool MedirDistanciaBool()
    {
        Vector3 metaPos = new Vector3(objetivo.position.x, this.transform.position.y, objetivo.position.z);
        float distancia = Vector3.Distance(transform.position, metaPos);

        if (distancia < distanciaMeta)
            return true;
        else
            return false;


        

    }
}
