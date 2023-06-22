using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalelMove : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if(creature.VisibleCreature.Count != 0)
        {
            float t = (creature.Position - creature.VisibleCreature[0].Position).magnitude / creature.Speed;
            Vector2 nextPosTarget = creature.VisibleCreature[0].Position + creature.VisibleCreature[0].Speed * creature.VisibleCreature[0].NowDirection * t;
            return nextPosTarget - creature.Position;
        }
        else
        {
            return creature.NowDirection;
        }
    }

    public string GetName()
    {
        return "Метод параллельного сближения";
    }
}
