using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEngine;
//using Com.MyCompany.MyGame;
using Photon.Pun;
public class UpdateText : MonoBehaviourPun
{
    private TextMeshProUGUI textComponent;
    private void Start()
    {        
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = " " + photonView.Owner.NickName;
    }

    public void Update()
    {
        
    }
}
