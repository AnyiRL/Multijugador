using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaPool : MonoBehaviour
{
    public GameObjectPool bombaPool;

    public void Update()
    {
        GameObject obj = bombaPool.GimmeInactiveGameObject();
        if (Input.GetButtonDown("Fire1"))
        {
            if (obj)
            {
                obj.SetActive(true); // ya no esta disponible en la pool
                obj.transform.position = transform.position;
                obj.GetComponent<Bomba>().SetDirection(transform.forward);
            }
        }
    }
}
