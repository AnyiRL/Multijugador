using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void SelectCharacter()
    {
        TMP_Dropdown dropdown = FindObjectOfType<TMP_Dropdown>();

        GameManager.Instance.characterSelection = dropdown.value;
    }
}
