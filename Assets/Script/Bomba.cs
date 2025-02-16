using System.Collections;
using System.Collections.Generic;
using Com.MyCompany.MyGame;
using Photon.Pun;
using UnityEngine;

public class Bomba : MonoBehaviour
{
   
    public float force;
    public float maxTime;
    public GameObject explosion;
    
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
            Explode();
        }
    }
    
    private void FixedUpdate()
    {   
        //rb.AddForce(Vector3.up * force* 5);
        rb.AddForce(dir.normalized * force);
    }
    public void SetDirection(Vector3 value)
    {
        dir = value;
    }
    void Explode()
    {
        //Instanciar el efecto de explosi¨®n
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        PhotonNetwork.Destroy(gameObject);
    }   
}
