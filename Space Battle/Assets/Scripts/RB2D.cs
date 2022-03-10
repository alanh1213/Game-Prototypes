using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB2D : MonoBehaviour
{
    public Vector3 vectorDeMovimiento;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(vectorDeMovimiento.x, vectorDeMovimiento.y, vectorDeMovimiento.z);
    }

    public void SetVelocity(Vector3 vectorDeMovimiento)
    {
        this.vectorDeMovimiento = vectorDeMovimiento;
    }
}
