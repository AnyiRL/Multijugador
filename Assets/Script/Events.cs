using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Events : MonoBehaviour
{
    public UnityEvent<int, float> events;

    // Start is called before the first frame update
    void Start()
    {
        events.AddListener(Explosion);
        events.Invoke(12, 0.3f); //invoca todo
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void Explosion(int entero, float dec)
    {
        Debug.Log("explosion" + entero + dec);
    }
}
