using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface ILogicMove
{
    public string GetName();
    public Vector2 Direction(Creature creature);
}
