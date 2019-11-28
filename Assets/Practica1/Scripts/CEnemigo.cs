using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemigo : Agente
{
    public string Id;
    public string nombre;
    public int vida;
    public int magia;
    public float _velocidadAgente;

    Animator anim;
    protected EnemigoB enemigoB;
   


    // Start is called before the first frame update
    void Start()
    {
        VelocidadAgente = _velocidadAgente;
        enemigoB = FindObjectOfType<EnemigoB>();

        BusquedaEnemigo(Id);

        anim = GetComponent<Animator>();
        destino= GameObject.Find("Destino").GetComponent<Transform>();
        objetivo = GameObject.Find("Destino").GetComponent<Transform>();

    }

    public void BusquedaEnemigo(string id)
    {
        for (int i = 0; i < enemigoB.enemigo.Count; i++)
        {
            if (id == enemigoB.enemigo[i].nombre)
            {
                nombre = enemigoB.enemigo[i].nombre;
                vida = enemigoB.enemigo[i].vida;
                magia = enemigoB.enemigo[i].magia;

            }
        }
    }



    private void Update()
    {
         

        if (MedirDistanciaBool())
        {
            ConfigurarDestino(destino);
            if (MedirDistanciaFloat() <= freno)
            {
           
                Debug.Log("Toma");
            }
        }
        else if (!MedirDistanciaBool())
        {
            VelocidadAgente = 0;
        }
       


        if (anim !=null)
        {
            anim.SetFloat("velocidad", VelocidadAgente);
        }
    }
}
