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
        grounded = Physics2D.OverlapCircle(traccionTrasera.transform.position,diametroRueda, suelo);
        //rotacion como angulo  de euler en grado respecto al transformacion principal nos da un Vector3 usamos 
        anguloMoto = transform.localEulerAngles.z;
        Debug.Log("aguloMoto" + anguloMoto);
        //corregimos el valor del angulo en negativo para que la lectura sea correcta
        if(anguloMoto > 180)
        {
            anguloMoto = anguloMoto-360;
        }
        Debug.Log("aguloMoto arreglado" + anguloMoto);
        if (grounded)
        {
            ruedaTrasera.motorSpeed = Mathf.Clamp(ruedaTrasera.motorSpeed - (aceleracion - gravedad * Mathf.PI* (anguloMoto/180)*80)*Input.GetAxis("Horizontal")*Time.deltaTime,velocidadMax,retrocesoMax);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ruedaTrasera.motorSpeed = 0;
            }
            ruedaDelantera = ruedaTrasera;
            ruedaArticulacion[0].motor = ruedaTrasera;
            ruedaArticulacion[1].motor = ruedaDelantera;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(traccionTrasera.transform.position, diametroRueda);
        
    }
}
