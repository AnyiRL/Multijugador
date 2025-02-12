using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MyCompany.MyGame;

public class CharacterInstantiation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerManager.LocalPlayerInstance == null)
        {
            Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
           
            
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                StartCoroutine(Wait());

            
        }
        else
        {
            Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.05f);
        PhotonNetwork.Instantiate(GameManager.Instance.characterSelection == 0 ? GameManager.Instance.playerPrefabBala.name : GameManager.Instance.playerPrefabBomba.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
    }


}
