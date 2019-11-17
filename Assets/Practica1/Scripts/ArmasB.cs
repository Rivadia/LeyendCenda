using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasB : MonoBehaviour
{
    public List<Armas> armasPunzoCortantes;
    public List<Armas> armasDeFuego;
    
    // Start is called before the first frame update
    void Awake()
    {
        armasPunzoCortantes.Add(new Armas("cuchillo", 10));
        armasDeFuego.Add(new Armas("magnum", 50, 6));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
