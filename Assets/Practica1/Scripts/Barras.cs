using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barras : MonoBehaviour
{
    public Slider[] barras;
    public int vida;
    CEnemigo vidaEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = GetComponentInParent<CEnemigo>();
        

        StartCoroutine("asignarBarra");
       
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (vidaEnemigo.vida==0)
        {
            transform.parent.gameObject.SetActive(false);
        }
        barras[0].value = vidaEnemigo.vida;
    }

    IEnumerator asignarvida()
    {
        yield return new WaitForSeconds(1);
        if (vidaEnemigo != null)
        {
            vida = vidaEnemigo.vida;
            barras[0].maxValue = vida;
            barras[0].value = barras[0].maxValue;
        }
    }

    IEnumerator asignarBarra()
    {
        yield return new WaitForSeconds(1);
        barras = new Slider[2];
        barras = GetComponentsInChildren<Slider>();
        vida = vidaEnemigo.vida;
        for (int i = 0; i < barras.Length; i++)
        {
            barras[i] = barras[i];
            if (i == 0)
            {
                barras[i].maxValue = vida;
                barras[i].value = barras[i].maxValue;
            }



        }
    }
     
}
