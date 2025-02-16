using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;
using Photon.Pun.Demo.SlotRacer.Utils;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public static GameManager Instance;
        string characterName;
       
        public TMP_InputField inputField;

        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefabBala;
        public GameObject playerPrefabBomba;

        public int characterSelection;

        private GameObject playerPrefab;
        private int player;
        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        #endregion

        private void Awake()
        {
            if(!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #region Public Methods
       //public int Player()
       // {
       //     return player ;
       // }
       // public void MenosPlayer(int playerA)
       // {
       //     player -= playerA;
       //     if (photonView.IsMine && player == 1)
       //     {
       //         PhotonNetwork.LoadLevel("Victory");
       //     }

       // }
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        public void Victory()
        {
            PhotonNetwork.LoadLevel("VictoryScene");
        }
        public void Dead()
        {
            PhotonNetwork.LoadLevel("DeadScene");

        }
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);           
        }
        public void SaveName(string name)
        {
            characterName = name;   
        }

        #endregion

        #region Private Methods

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
                return;
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        #endregion

        #region Photon Callbacks

        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

                LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

                LoadArena();
            }
        }

        #endregion
        
    }
}
