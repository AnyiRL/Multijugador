using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius;
    private Rigidbody rb;
    private float currentTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 0.5f)
        {
            currentTime = 0;
            Destroy(gameObject);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Visualizar el ¨¢rea de explosi¨®n en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
