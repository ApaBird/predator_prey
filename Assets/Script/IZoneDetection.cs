using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZoneDetection 
{
    bool InZone(Creature me, Creature it);

    void DrawZone(UnityCreature me);
}
