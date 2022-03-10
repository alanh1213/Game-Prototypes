using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    Animator anim;

    [Header("Atributos")]
    [SerializeField] private float velocidadRotacion = 20f;
    [SerializeField] private float velocidadRotacionCanones = 5f;
    [SerializeField] private float rangoDeArmas = 50f;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private GameObject kineticAmmoPrefab;
    [SerializeField] private LayerMask queEsEnemigo;
    [Header("Unity Input Fieds")]
    public Transform vectorObjetivo;
    [SerializeField] private Transform posicionDisparo1, posicionDisparo2;
    [SerializeField] private Transform canones;
    private float startFireRate;



    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        startFireRate = fireRate;
    }
    private void Update() 
    {
        fireRate -= Time.deltaTime;
        ApuntarAlObjetivo();
        ApuntarCanones();

        Debug.DrawRay(canones.position, canones.forward * rangoDeArmas, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(canones.position, canones.forward * rangoDeArmas, out hit, queEsEnemigo))
        {
            //Si el raycast impacta un collider enemigo
            //Disparo
            Debug.Log("Disparo");
            Disparar();
        }else
        {

        }
    }

    private void ApuntarAlObjetivo()
    {
        //crea una flecha/vector desde la posicion entre este objeto y el objetivo
        Vector3 _direction = (vectorObjetivo.position - transform.position).normalized;

        //genero y almaceno la rotacion necesaria para apuntar a esa flecha
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);

        //rotamos lentamente el objeto hacia la rotacion generada previamente
        //transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0 ,_lookRotation.y, 0, _lookRotation.w), velocidadRotacion * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, velocidadRotacion * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    private void ApuntarCanones()
    {
        //crea una flecha/vector desde la posicion entre este objeto y el objetivo
        Vector3 _direction = (vectorObjetivo.position - canones.position).normalized;

        //genero y almaceno la rotacion necesaria para apuntar a esa flecha
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);

        canones.rotation = Quaternion.RotateTowards(canones.rotation, _lookRotation, velocidadRotacion * Time.deltaTime);
        canones.localEulerAngles = new Vector3(canones.localEulerAngles.x, 0, 0);
    }

    private void Disparar()
    {
        if(fireRate <= 0)
        {
            anim.SetTrigger("fire");
            GameObject disparo1 = Instantiate(kineticAmmoPrefab , posicionDisparo1.position, posicionDisparo1.rotation);
            GameObject disparo2 = Instantiate(kineticAmmoPrefab , posicionDisparo2.position, posicionDisparo2.rotation);

            disparo1.GetComponent<KineticShot>().vectorDireccion = canones.forward;
            disparo2.GetComponent<KineticShot>().vectorDireccion = canones.forward;

            fireRate = startFireRate;
        }else
        {
            return;
        }

    }
    
}
