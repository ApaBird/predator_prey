using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRender : MonoBehaviour
{
    public static void DrawAngle(float angel, float direct, Vector3 position, LineRenderer line)
    {
        line.positionCount = 3;
        Vector2 directV = new Vector2(Mathf.Cos(direct * Mathf.Deg2Rad) + position.x, Mathf.Sin(direct * Mathf.Deg2Rad) + position.y).normalized * 100;
        Vector2 perpendicular = new Vector2(1, directV.x / directV.y).normalized * 100 * Mathf.Sin(direct / 2 * Mathf.Deg2Rad);
        line.SetPosition(0, new Vector3(directV.x + perpendicular.x, position.y, directV.y + perpendicular.y));
        line.SetPosition(1, position);
        line.SetPosition(2, new Vector3(directV.x - perpendicular.x, position.y, directV.y - perpendicular.y));
    }
}
