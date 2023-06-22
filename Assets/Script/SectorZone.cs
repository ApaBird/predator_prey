using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorZone : IZoneDetection
{
    public void DrawZone(UnityCreature me)
    {
        SectorRender.DrawSector(me.Radius.value, me.AngelDetection.value, me.DirectionAngel.value, me.transform.position, me.LineZone, me.Creature.Terrain);
    }

    public bool InZone(Creature me, Creature it)
    {
        return new Vector2(me.Position.x - it.Position.x, me.Position.y - it.Position.y).magnitude < me.Radius &&
                Vector2.Angle(me.NowDirection, it.Position - me.Position) < me.AngelDetection / 2;
    }
}
