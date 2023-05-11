using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIParametrDropBox : MonoBehaviour
{
    [SerializeField] private TMP_Text textParametr;
    [SerializeField] private TMP_Dropdown inputField;
    private ParametrList parametr;
    private bool select = false;


    public void SetParametr(ParametrList param)
    {
        parametr = param;
        textParametr.text = parametr.name;
        inputField.ClearOptions();
        inputField.AddOptions(param.value);
        inputField.value = param.value.IndexOf(param.selected);
    }

    public void OnChange(int id)
    {
        parametr.selected = parametr.value[id];
    }
}
