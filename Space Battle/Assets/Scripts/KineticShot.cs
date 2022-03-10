using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticShot : MonoBehaviour
{
    RB2D rb2d;
    [SerializeField] private float zVelocidad = 10f;
    public Vector3 vectorDireccion;

    private void Awake() 
    {
        rb2d = GetComponent<RB2D>();
        
    }

    private void Update()
    {
        Vector3 vectorFinal = vectorDireccion.normalized * zVelocidad;
        rb2d.SetVelocity(vectorFinal);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag != gameObject.tag)
        {
            Destroy(gameObject);
        }
    }
}
