using Com.MyCompany.MyGame;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPool : MonoBehaviour
{
    public GameObjectPool balaPool;
    public void Update()
    {
        GameObject obj = balaPool.GimmeInactiveGameObject();
        if (Input.GetButtonDown("Fire1"))
        {
            if (obj)
            {
                obj.SetActive(true); // ya no esta disponible en la pool
                Vector3 balapos = new Vector3(transform.position.x, transform.position.y * 10, transform.position.z);
                obj.transform.position = balapos;
                //obj.GetComponent<Bala>().SetDirection(transform.forward);
            }
        }
    }
}
