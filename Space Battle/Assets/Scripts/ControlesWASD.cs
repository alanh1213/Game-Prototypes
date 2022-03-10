using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesWASD : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento = 10f;
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        this.transform.Translate(xAxis * velocidadMovimiento * Time.deltaTime, 0 ,zAxis * velocidadMovimiento * Time.deltaTime, Space.Self);
    }
}
