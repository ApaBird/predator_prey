using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeSector : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if (creature.VisibleCreature.Count != 0)
        {
            Creature predator = creature.VisibleCreature[0];
            float distance = (creature.Position - predator.Position).magnitude;
            float angel = Vector2.Angle(creature.Position - predator.Position, predator.NowDirection) * Mathf.Deg2Rad;
            if (distance * Mathf.Sin(angel) <= predator.Radius * Mathf.Sin(predator.AngelDetection/2 * Mathf.Deg2Rad) && distance > predator.Radius)
            {
                float angelSector = Mathf.Sign(Vector2.SignedAngle(predator.NowDirection, creature.Position - predator.Position)) * predator.AngelDetection * Mathf.Deg2Rad;
                Vector2 dotTarget = predator.Position + (new Vector2(
                                                                    Mathf.Cos(angelSector) * predator.NowDirection.x - Mathf.Sin(angelSector) * predator.NowDirection.y,
                                                                    Mathf.Cos(angelSector) * predator.NowDirection.y + Mathf.Sin(angelSector) * predator.NowDirection.x
                                                                    ).normalized * predator.Radius);
                return dotTarget - creature.Position;
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
