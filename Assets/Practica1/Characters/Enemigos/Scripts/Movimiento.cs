using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Aqui va tu objeto vacio model")]
    public GameObject model;
    public string[] tipoAtaque;
    public bool MovimientoAtaque;
    
    public int contador;
    Animator anim;
    float velocidad;
    float velocidadLateral;
    float rotationSpeed=2f;
    Quaternion targetModelRotation;

    // Start is called before the first frame update
    void Start()
    {
        MovimientoAtaque = false;
        contador = 0;
        anim = GetComponent<Animator>();
        velocidad = 6;
        velocidadLateral = 6;
        
        targetModelRotation = Quaternion.Euler(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
       

        ControlGeneralMovimiento();
        Ataque(tipoAtaque[contador]);
        CambioAtaque();
       

    }//Fin de update;






    void ControlGeneralMovimiento()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            MovimientoAtaque = true;
        }
        else
        {
            MovimientoAtaque = false;
        }



        if (MovimientoAtaque == false)
        {
            anim.SetLayerWeight(0, 1);
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(2, 0);
            ControlMovimiento();
        }
        else if (MovimientoAtaque == true)
        {
            anim.SetLayerWeight(0, 0);
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(2, 1);
            ControlMovimientoAtaque();
        }





    }

    void ControlMovimiento()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direccion = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);

        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, Time.deltaTime * rotationSpeed);

        transform.Translate(direccion);
        anim.SetFloat("Velocidad", vertical * velocidad);
        anim.SetFloat("velocidadLateral", horizontal * velocidadLateral);
        direccion.Normalize();


        if (direccion.z > 0)
        {
            targetModelRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direccion.z < 0)
        {
            targetModelRotation = Quaternion.Euler(0, 180, 0);
        }

        if (direccion.x > 0)
        {
            targetModelRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direccion.x < 0)
        {
            targetModelRotation = Quaternion.Euler(0, 270, 0);
        }
    }

    void ControlMovimientoAtaque()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direccion = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);

       

        transform.Translate(direccion);
        anim.SetFloat("velocidadAtaqueFrontal", vertical * velocidad);
        anim.SetFloat("velocidadAtaqueLateral", horizontal * velocidadLateral);
        direccion.Normalize();


    }


    //void Ataque()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        anim.SetBool("Ataque",true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Ataque", false);
    //    }
    //}

    void Ataque(string tipoAtaque)
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            anim.SetBool(tipoAtaque, true);
        }
        else
        {
            anim.SetBool(tipoAtaque, false);
        }
    }

    void Ataque(int contador,string contadorText)
    {
            anim.SetInteger(contadorText, contador);
            
        
    }

    void CambioAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            contador++;
            if (contador > tipoAtaque.Length-1)
            {
                contador = 0;
            }
        }
    }

    
}
