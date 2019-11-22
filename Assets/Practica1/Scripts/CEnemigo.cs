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
    EnemigoB enemigoB;


    // Start is called before the first frame update
    void Start()
    {
        VelocidadAgente = _velocidadAgente;
        enemigoB = FindObjectOfType<EnemigoB>();

        BusquedaEnemigo(Id);

        anim = GetComponent<Animator>();

    }

    private void BusquedaEnemigo(string id)
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
        ConfigurarDestino(destino);

        if (anim !=null)
        {
            anim.SetFloat("velocidad", VelocidadAgente);
        }
    }
}
