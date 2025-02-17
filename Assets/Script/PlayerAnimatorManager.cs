using UnityEngine;
using System.Collections;
using Photon.Pun;

namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : MonoBehaviourPun //IPunObservable
    {
        private Animator animator;
        private PlayerManager playerManager;
        
        void Start()
        {
            animator = GetComponent<Animator>();
            playerManager = GetComponent<PlayerManager>();
        }

        // Update is called once per frame
        void Update()
        {
            //if (!photonView.IsMine)
            //    return;
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    animator.SetBool("shooting", true);
            //}
            //else
            //{
            //    animator.SetBool("shooting", false);
            //}
        }
        private void LateUpdate()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            animator.SetFloat("Blend", playerManager.GetCurrentSpeed() / playerManager.runningSpeed);  //devuelve la longitud del vector
        }
        //#region IPunObservable implementation

        //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        //{
        //    if (stream.IsWriting)
        //    {
        //        // We own this player: send the others our data

        //        stream.SendNext(animator);
        //    }
        //    else
        //    {
        //        // Network player, receive data

        //        this.animator = (float)stream.ReceiveNext();
        //    }
        //}

        //#endregion

    }
}