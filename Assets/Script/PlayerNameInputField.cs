using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNameInputField : MonoBehaviour
{
    const string playerNameKey = "PlayerName";
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = "DEFAULT NAME";
        TMP_InputField _inputField = GetComponent<TMP_InputField>();

        if (_inputField)
        {
            if (PlayerPrefs.HasKey(playerNameKey))  //si los settings del usuario tienen key  "diccionario"
            {
                defaultName = PlayerPrefs.GetString(playerNameKey);
                _inputField.text = defaultName;   //guardar nombre de "usuario"
            }
        }
        PhotonNetwork.NickName = defaultName;
    }

    public  void SetPlayerName()
    {
        TMP_InputField _InputField = GetComponent<TMP_InputField>();
        string playerName = _InputField.text; // lo que ha introducido el usuariio

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString(playerNameKey, playerName);
            PhotonNetwork.NickName = playerName;
        }
    }
  
}
