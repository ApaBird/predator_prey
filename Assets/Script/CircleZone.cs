using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CircleZone : IZoneDetection
{
    public void DrawZone(UnityCreature me)
    {
        CircleRender.DrawCircle(me.Radius.value, me.gameObject.transform.position, me.LineZone, me.Creature.Terrain);
    }

    public bool InZone(Creature me, Creature it)
    {
        return new Vector2(me.Position.x - it.Position.x, me.Position.y - it.Position.y).magnitude < me.Radius;
    }

}
