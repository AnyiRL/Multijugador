using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Com.MyCompany.MyGame;
using Photon.Pun;
public class UpdateText : MonoBehaviourPun
{
    private TMP_Text textComponent;
    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    public void Update()
    {
        textComponent.text = " " + photonView.Owner.NickName;
    }
}
