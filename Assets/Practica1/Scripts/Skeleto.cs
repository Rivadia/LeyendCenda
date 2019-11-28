using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleto : Agente
{
    public string Id;
    public string nombre;
    public int vida;
    public int magia;
    public float _velocidadAgente;

    Animator anim;
    EnemigoB enemigoB;
  
    // Start is called before the first frame update
    void Start()
    {
        VelocidadAgente = velocidad;
        enemigoB = FindObjectOfType<EnemigoB>();

        BusquedaEnemigo(Id);

        this.anim = GetComponent<Animator>();
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



    // Update is called once per frame
    void Update()
    {
        if (MedirDistanciaBool())
        {
            ConfigurarDestino(destino);

            if (MedirDistanciaFloat() <= freno)
            {
                Debug.Log("Tomaaaaa");
                anim.SetBool("Ataque", true);

            }
            else
            {
            
                anim.SetBool("Ataque", false);
            }
        }
        else if (!MedirDistanciaBool())
        {
            VelocidadAgente = 0;
        }



        if (anim != null)
        {
            anim.SetFloat("velocidad", VelocidadAgente);
        }
    }
}
