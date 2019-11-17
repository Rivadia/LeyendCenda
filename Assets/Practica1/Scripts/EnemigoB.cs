using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoB : MonoBehaviour
{
    public List<Enemigo> enemigo;


    // Start is called before the first frame update
    void Awake()
    {
        enemigo.Add(new Enemigo(100, 50, "Hongito"));
        enemigo.Add(new Enemigo(200, 500, "Momia"));
        enemigo.Add(new Enemigo(50, 50, "Conejito"));
        enemigo.Add(new Enemigo(100, 1000, "CuboMalo"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
