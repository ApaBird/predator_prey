using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreemptionMove : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if (creature.VisibleCreature.Count > 0)
        {
            Creature target = creature.VisibleCreature[0];
            float d = new Vector2(creature.Position.x - target.Position.x, creature.Position.y - target.Position.y).magnitude;
            float t = d / creature.Speed;
            Vector2 targetF = target.Position + target.NowDirection * t * target.Speed;
            float tetta = Mathf.Atan2(targetF.y - creature.Position.y, targetF.x - creature.Position.x);
            float alpha0 = Mathf.Atan2(d * Mathf.Sin(tetta), d * Mathf.Cos(tetta) - target.Speed * t);
            return new Vector2(-Mathf.Cos(tetta+alpha0), -Mathf.Sin(tetta + alpha0));
        }
        else
        {
            return creature.NowDirection;
        }
    }

    public string GetName()
    {
        return "”преждение";
    }
}
