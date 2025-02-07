using UnityEngine;
using UnityEngine.EventSystems;

using Photon.Pun;

using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        public float walkingSpeed, runningSpeed, acceleration, mouseSens, gravityScale, jumpForce;
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        [Tooltip("The current Health of our player")]
        public float health = 1f;
        
        public Slider vidaVisual;
        private float yVelocity = 0, currentSpeed;
        private CharacterController characterController;
        private Vector3 movementVector;
        bool IsFiring;

        private void Awake()
        {
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            gravityScale = Mathf.Abs(gravityScale);

            CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();

            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                }
            }
            else
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
            }

#if UNITY_5_4_OR_NEWER
            // Unity 5.4 has a new scene management. register a method to call CalledOnLevelWasLoaded.
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
#endif
        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine && PhotonNetwork.IsConnected)
            {
                return;
            }

            if (photonView.IsMine)
            {
                //ProcessInputs();
                HealthValue();
                
                if (health <= 0f)
                {
                    GameManager.Instance.LeaveRoom();
                }
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
            float mouseX = Input.GetAxis("Mouse X");
            bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

            Jump(jumpPressed);
            Movement(x, z, shiftPressed);
            RotatePlayer(mouseX);
        }
        private void HealthValue()
        {
            vidaVisual.GetComponent<Slider>().value = health;
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
        void OnTriggerEnter(Collider collision)
        {
            
            if (!photonView.IsMine)
            {
                return;
            }

            shoot PMComponent = collision.gameObject.GetComponent<shoot>();

            if (PMComponent != null)
            {
                health -= 0.1f;
            }
            
        }
        //void OnTriggerStay(Collider other)
        //{
        //    // we dont' do anything if we are not the local player.
        //    if (!photonView.IsMine)
        //    {
        //        return;
        //    }
        //    // We are only interested in Beamers
        //    // we should be using tags but for the sake of distribution, let's simply check by name.
        //    if (!other.name.Contains("Beam"))
        //    {
        //        return;
        //    }
        //    // we slowly affect health when beam is constantly hitting us, so player has to move to prevent death.
        //    health -= 0.1f * Time.deltaTime;
        //}
        void ProcessInputs()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!IsFiring)
                {
                    IsFiring = true;
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                if (IsFiring)
                {
                    IsFiring = false;
                }
            }
        }

#if UNITY_5_4_OR_NEWER
        void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadingMode)
        {
            this.CalledOnLevelWasLoaded(scene.buildIndex);
        }
        public override void OnDisable()
        {
            // Always call the base to remove callbacks
            base.OnDisable();
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }
#endif
        void CalledOnLevelWasLoaded(int level)
        {
            // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
            if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
            {
                transform.position = new Vector3(0f, 5f, 0f);
            }
        }
    }
}