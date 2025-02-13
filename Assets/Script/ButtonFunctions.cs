using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public TMP_InputField inputField;
    public void SelectCharacter()
    {
        TMP_Dropdown dropdown = FindObjectOfType<TMP_Dropdown>();

        GameManager.Instance.characterSelection = dropdown.value;
    }
    public void SaveInputName()
    {
        GameManager.Instance.SaveName(inputField.text);
    }
    
}
