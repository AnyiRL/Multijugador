//using System.Collections;
using Com.MyCompany.MyGame;
//using System.Collections.Generic;
using UnityEngine;
//using Photon.Realtime;
using Photon.Pun;

public class shoot : MonoBehaviourPun
{
    public GameObject prefab;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        
    }

    // Update is called once per frame
    void Update()
    {
       // prefab.GetComponent<Bala>().SetDirection(transform.forward);
        if (!photonView.IsMine)
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {      
           
            animator.SetBool("shooting", true);
        }
        else
        {
            animator.SetBool("shooting", false);
        }      
    }
    
    public void DoAnimation()
    {
        if (GameManager.Instance.characterSelection == 0)
        {            
            GameObject b = PhotonNetwork.Instantiate(prefab.name, transform.position, Quaternion.identity);
            Vector3 balapos = new Vector3(transform.position.x, transform.position.y * 3.5f, transform.position.z );
            b.transform.position = balapos;
            b.GetComponent<Bala>().SetDirection(transform.forward);
        }

        else if (GameManager.Instance.characterSelection == 1)
        {                      
            GameObject bom = PhotonNetwork.Instantiate(prefab.name,transform.position, Quaternion.identity);
            Vector3 bompos = new Vector3(transform.position.x, transform.position.y * 3.5f, transform.position.z);
            bom.transform.position = bompos;
            //bom.GetComponent<Bomba>().SetDirection(transform.position);
        }
    }
}
