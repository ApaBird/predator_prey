using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if (creature.VisibleCreature.Count > 0)
        {
            Creature target = creature.VisibleCreature[0];
            return new Vector2(target.Position.x - creature.Position.x, target.Position.y - creature.Position.y);
        }
        else
        {
            return creature.NowDirection;
        }
    }

    public string GetName()
    {
        return "Погоня";
    }
}
