using UnityEngine;
using UnityEngine.EventSystems;

using Photon.Pun;

using System.Collections;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
    /// <summary>
    /// Player manager.
    /// Handles fire Input and Beams.
    /// </summary>
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        public float walkingSpeed, runningSpeed, acceleration, mouseSens, gravityScale, jumpForce;

        private float yVelocity = 0, currentSpeed;
        private CharacterController characterController;
        private Vector3 movementVector;

        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            gravityScale = Mathf.Abs(gravityScale);
        }

        // Update is called once per frame
        void Update()
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
            float mouseX = Input.GetAxis("Mouse X");
            bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

            Jump(jumpPressed);
            Movement(x, z, shiftPressed);
            RotatePlayer(mouseX);
        }

        void Jump(bool jumpPressed)
        {
            if (jumpPressed && characterController.isGrounded)
            {
                yVelocity = 0;
                yVelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale);   //raiz cuadrada
            }
        }

        void Movement(float x, float z, bool shiftPressed)
        {
            //if (shiftPressed)
            //    currentSpeed = runningSpeed;
            //else
            //    currentSpeed = walkingSpeed;
            if (shiftPressed && (x != 0 || z != 0))
            {
                currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, acceleration * Time.deltaTime);
            }
            else if (x != 0 || z != 0)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, acceleration * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }

            movementVector = transform.forward * currentSpeed * z + transform.right * currentSpeed * x;

            if (!characterController.isGrounded)
            {
                yVelocity -= gravityScale;
            }
            movementVector.y = yVelocity;

            movementVector *= Time.deltaTime;           //mV = mV * Dt  para que se mueva igual en todos los ordenadores

            characterController.Move(movementVector);
        }


        void RotatePlayer(float mouseX)
        {
            Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime;     //new Vector3(0, 5, 0) * Time.deltaTime  rotación c
            transform.Rotate(rotation); // rota a la direccion que se indica
        }
        public float GetCurrentSpeed()
        {
            return currentSpeed;
        }
    }
}