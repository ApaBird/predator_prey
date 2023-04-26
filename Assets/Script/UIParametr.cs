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
    private bool select = false;
    

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
            Debug.Log(valueFloat);
        }
    }

    public void Select() => select = true;

    public void Deselect() => select = false;

    private void FixedUpdate()
    {
        if (!select)
            textValues.text = parametr.value.ToString();
    }
}
