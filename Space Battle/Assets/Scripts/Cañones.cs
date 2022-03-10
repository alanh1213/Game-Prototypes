using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañones : MonoBehaviour
{
    public Transform alturaObjetivo;
    [SerializeField] private float velocidadRotacion = 20f;

    private void Update() 
    {
        //crea una flecha/vector desde la posicion entre este objeto y el objetivo
        Vector3 _direction = (alturaObjetivo.position - transform.position).normalized;

        //genero y almaceno la rotacion necesaria para apuntar a esa flecha
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);

        //rotamos lentamente el objeto hacia la rotacion generada previamente


        //transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0 ,_lookRotation.y, 0, _lookRotation.w), velocidadRotacion * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(_lookRotation.x , _lookRotation.y , 0, _lookRotation.w), velocidadRotacion * Time.deltaTime);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);

    }
}
