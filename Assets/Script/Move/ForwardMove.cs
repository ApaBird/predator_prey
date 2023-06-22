using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMove : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        return creature.NowDirection;
    }

    public string GetName()
    {
        return "Вперед";
    }
}
