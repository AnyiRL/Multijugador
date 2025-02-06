using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class shoot : MonoBehaviourPun
{
    public GameObject bulletprefab;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            PhotonNetwork.Instantiate(bulletprefab.name, transform.position, Quaternion.identity);
            animator.SetBool("shooting", true);
        }
        else
        {
            animator.SetBool("shooting", false);
        }
        
    }
}
