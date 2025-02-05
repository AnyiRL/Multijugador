using Com.MyCompany.MyGame;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPool : MonoBehaviour
{
    public GameObjectPool balaPool;
    
    public void Shoot()
    {
        GameObject obj = balaPool.GimmeInactiveGameObject();
        if (Input.GetButtonDown("Fire1"))
        {
            if (obj)
            {
                obj.SetActive(true); // ya no esta disponible en la pool
                obj.transform.position = transform.position;
                obj.GetComponent<Bala>().SetDirection(transform.forward);
            }
        }
    }
    
}
