using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAngle : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if (creature.VisibleCreature.Count != 0)
        {
            Creature predator = null;
            foreach(Creature creat in creature.VisibleCreature)
            {
                float minDistan = creature.Radius;
                if(creat.Tag != creature.Tag)
                {
                    if ((creature.Position - creat.Position).magnitude < minDistan)
                    {
                        predator = creat;
                        minDistan = (creature.Position - creat.Position).magnitude;
                    }
                }
            }
            if (predator != null)
            {
                float distance = (creature.Position - predator.Position).magnitude;
                float angel = Vector2.Angle(creature.Position - predator.Position, predator.NowDirection) * Mathf.Deg2Rad;
                if (distance * Mathf.Sin(angel) <= predator.Radius * Mathf.Sin(predator.AngelDetection / 2 * Mathf.Deg2Rad))
                {
                    float sign = -Mathf.Sign(Vector2.SignedAngle(predator.NowDirection, creature.Position - predator.Position));
                    Vector2 p;
                    if (predator.NowDirection.x != 0) p = new Vector2(predator.NowDirection.y / predator.NowDirection.x, 1);
                    else p = new Vector2(1, predator.NowDirection.x / predator.NowDirection.y);

                    return sign * p * Mathf.Cos(predator.AngelDetection / 2 * Mathf.Deg2Rad) - predator.NowDirection;
                }
                else
                {
                    return creature.NowDirection;
                }
            }
            else
            {
                return creature.NowDirection;
            }
        }
        else
        {
            return creature.NowDirection;
        }
    }

    public string GetName()
    {
        return "Уклонение от сектора";
    }
}
