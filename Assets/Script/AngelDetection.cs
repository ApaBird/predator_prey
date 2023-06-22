using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelDetection : IZoneDetection
{
    public void DrawZone(UnityCreature me)
    {
        SectorRender.DrawSector(1000, me.AngelDetection.value, me.DirectionAngel.value, me.transform.position, me.LineZone, me.Creature.Terrain);
    }

    public bool InZone(Creature me, Creature it)
    {
        return Vector2.Angle(me.NowDirection, it.Position - me.Position) < me.AngelDetection/2;
    }
}
