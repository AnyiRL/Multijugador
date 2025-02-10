using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float speed;
    public float gravityScale;
    public float force;
    public float maxTime;

    private float yVelocity;
    private float currentTime;
    private Vector3 dir;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            gameObject.SetActive(false); // se "devuelve" a la pool 
        }
    }
    
    private void FixedUpdate()
    {
        yVelocity += Mathf.Sqrt(force * 3 * gravityScale);
        rb.AddForce(Vector3.up * force);
        rb.useGravity = true;
        rb.velocity = speed * dir;
        //rb.velocity = CalcularVelocidadInicial();
    }
    public void SetDirection(Vector3 value)
    {
        dir = value;
    }
    //Vector3 CalcularVelocidadInicial()
    //{
    //    Vector3 desplazamientoP = objTrans.transform.position - transform.position;

    //    float velocityX, velocityY, velocityZ;
    //    velocityY = Mathf.Sqrt(-2 * gravity * h);
    //    velocityX = desplazamientoP.x / ((velocityY / gravity) + Mathf.Sqrt(2 * desplazamientoP.y - h) / gravity);  //ecuacion
    //    velocityZ = desplazamientoP.z / ((velocityY / gravity) + Mathf.Sqrt(2 * desplazamientoP.y - h) / gravity);

    //    return new Vector3(velocityX, velocityY, velocityZ);
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    if (currentTime > 2)
    //    {
    //        currentTime = 0;
    //        DrawLines();
    //    }
    //}
    //void DrawLines()
    //{
    //    Vector3 desde, hacia;
    //    desde = transform.position;
    //    hacia = objTrans.transform.position;
    //    Gizmos.DrawLine(desde,hacia);
    //}
}
