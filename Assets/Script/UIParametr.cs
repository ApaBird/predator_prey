using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIParametr : MonoBehaviour
{
    [SerializeField] private TMP_Text textParametr;
    [SerializeField] private TMP_Text textValues;
    [SerializeField] private TMP_InputField inputField;
    private Parametr parametr;
    

    public void SetParametr(Parametr param)
    {
        parametr = param;
        textParametr.text = parametr.name;
        textValues.text = parametr.value.ToString();
    }

    public void SetNewValue()
    {
        float valueFloat;
        if (float.TryParse(inputField.text, out valueFloat))
        {
            parametr.value = valueFloat;
        }
    }
}
