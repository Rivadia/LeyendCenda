using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armas 
{
    public string nombre;
    public int daño;
    public int municion;
    public int ExtraPorExplosion;


    public Armas(string n, int d)
    {
        this.nombre = n;
        this.daño = d;
    }

    public Armas(string n, int daño, int m)
    {
        this.nombre = n;
        this.daño = daño;
        this.municion = m;

    }
}
