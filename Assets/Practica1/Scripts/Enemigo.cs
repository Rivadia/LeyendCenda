using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Enemigo 
{
    public string nombre;
    public int vida;
    public int magia;

    public Enemigo(int v,int m, string n)
    {
        this.nombre = n;
        this.vida = v;
        this.magia = m;
    }
}
