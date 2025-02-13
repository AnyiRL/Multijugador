using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
   
    public float force;
    public float maxTime;
    
    private float currentTime;
    private Vector3 dir;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate()
    {   
        //rb.AddForce(Vector3.up * force* 5);
        rb.AddForce(dir * force);
    }
    public void SetDirection(Vector3 value)
    {
        dir = value;
    }

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
