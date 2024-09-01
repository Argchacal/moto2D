using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motoScript : MonoBehaviour
{
    //es un array que contiene las 2 ruedas
    WheelJoint2D[] ruedaArticulacion;
    //articulaciones de cada rueda
    JointMotor2D ruedaDelantera;
    JointMotor2D ruedaTrasera;
    private float gravedad = 9.8f;
    public float anguloMoto = 0;
    public float aceleracion = 0;
    public float velocidadMax = -2000f;
    public float retrocesoMax = 1000f;
    public float diametroRueda;
    public bool grounded = false;
    public LayerMask suelo;
    public Transform traccionTrasera;


    void Start()
    {
        ruedaArticulacion = gameObject.GetComponents<WheelJoint2D>();
        ruedaDelantera = ruedaArticulacion[0].motor;
        ruedaTrasera = ruedaArticulacion[1].motor;


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
