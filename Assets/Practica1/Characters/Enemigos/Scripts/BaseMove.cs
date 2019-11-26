using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    public float velocidad;
    public float velRot;
    public bool onRotation = false;
    protected Rigidbody rb;
    protected Animator anim;
    protected float hor;
    protected float vert;
    protected float mouseHor;
    
    protected void AccesoComponentes()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    protected void Aceleracion(float v)
    {
        hor = Input.GetAxis("Horizontal")*v*Time.deltaTime;
        vert = Input.GetAxis("Vertical") * v * Time.deltaTime;

        rb.velocity = new Vector3(hor, rb.velocity.y, vert);
  
       

        anim.SetFloat("Velocidad", vert);
        anim.SetFloat("veloLateral", hor);
     

    }


    protected void Rotacion(float r)
    {
        mouseHor = Input.GetAxis("Mouse X") * r*Time.deltaTime;
        rb.AddRelativeTorque(rb.transform.up * mouseHor);

        //var angle = transform.localEulerAngles.y;
        //angle = (angle > 180) ? angle - 360 : angle;
       
        float angle = transform.localEulerAngles.y;
       
        
        if (transform.localEulerAngles.y > 90 && transform.localEulerAngles.y < 180)
        {
            onRotation = true;
            Debug.Log("estoyrotando");
        }

        if (angle > 180)
        {
           
            angle -= 360;
            
            if (angle <-90 )
            {
                onRotation = true;
                Debug.Log("estoyrotandopalotrolado");
            }
        }
        if (onRotation == true)
        {
           
            transform.localEulerAngles = Vector3.zero * Time.time* 0.1f;
            onRotation = false;
        }
        

    }

    #region comprobacion de terreno
    public LayerMask mask;
    protected bool isGrounded()
    {
        Vector3 rayOrigin = GetComponent<Collider>().bounds.center;
        float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        Ray ray = new Ray();
        ray.origin = rayOrigin;
        ray.direction = Vector3.down;
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        //Detecta la colision de un objeto hacia el terreno para generar alguna accion
        if (Physics.Raycast(ray.origin, ray.direction, rayDistance, mask))
        {
            Debug.Log("Esta chocando");
            return true;
        }
        else
            return false;
    }
    #endregion

}
