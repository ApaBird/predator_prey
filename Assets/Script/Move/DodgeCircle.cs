using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCircle : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if (creature.VisibleCreature.Count != 0)
        {
            Creature predator = creature.VisibleCreature[0];
            float distance = (creature.Position - predator.Position).magnitude;
            float angel = Vector2.Angle(creature.Position - predator.Position, predator.NowDirection) * Mathf.Deg2Rad;
            if (distance * Mathf.Sin(angel) <= predator.Radius && distance > predator.Radius)
            {
                float answer = (Mathf.Asin(predator.Radius / distance) * Mathf.Rad2Deg - Vector2.Angle(creature.NowDirection, predator.Position - creature.Position)) * Mathf.Deg2Rad;
                return creature.NowDirection + Mathf.Sign(Vector2.SignedAngle(creature.NowDirection, predator.Position - creature.Position)) * new Vector2(Mathf.Cos(answer), Mathf.Sin(answer));
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
        return "Уклонение от круговой";
    }
}
