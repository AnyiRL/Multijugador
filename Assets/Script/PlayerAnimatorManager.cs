using UnityEngine;
using System.Collections;

namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : MonoBehaviour
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
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("shooting", true);
            }
            else
            {
                animator.SetBool("shooting", false);
            }
        }
        private void LateUpdate()
        {
            animator.SetFloat("Blend", playerManager.GetCurrentSpeed() / playerManager.runningSpeed);  //devuelve la longitud del vector
        }

       
    }
}