using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Com.MyCompany.MyGame;
public class Health : MonoBehaviourPun
{
    private int valor = 10;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        PlayerManager PMComponent = collision.gameObject.GetComponent<PlayerManager>();
        if (!photonView.IsMine)
            return;
        if (PMComponent != null)
        {
            //GameManager.instance.QuitLifes(valor);
        }

    }
}
