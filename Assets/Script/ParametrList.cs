using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrList
{
    public string name;
    public List<string> value;
    public string selected;

    public ParametrList(string name, List<string> value)
    {
        this.name = name;
        this.value = value;
        this.selected = value[0];
    }
}
