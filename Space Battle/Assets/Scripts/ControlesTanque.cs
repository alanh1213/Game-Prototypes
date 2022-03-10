using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTanque : MonoBehaviour
{
    public float velocidadDeRotacion;
    public float velocidadDeMovimiento;
    public bool aiming;
    Animator anim;
    public AudioSource audioSourceZapatillas;
    public GameObject camara;
    float xAxis;
    float zAxis;
    RB2D rb2d;
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<RB2D>();
    }

    
    void Update()
    {
        
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, xAxis * velocidadDeRotacion * Time.deltaTime, 0, Space.Self);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            velocidadDeMovimiento = 3.5f;
            //audioSourceZapatillas.pitch = 2.4f;
        }else
        {
            velocidadDeMovimiento = 1.5f;
            //audioSourceZapatillas.pitch = 1.5f;
        }

        
        //Movimiento usando Rigidbody
        if(zAxis != 0)rb2d.SetVelocity(transform.forward * zAxis * velocidadDeMovimiento);
        
        
    }

    
}
