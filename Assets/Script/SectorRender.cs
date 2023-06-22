using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorRender : MonoBehaviour
{
    public static void DrawSector(float radius, float angel, float direct, Vector3 position, LineRenderer line, Terrain t)
    {
        int countStep = 100;
        line.positionCount = countStep + 1;
        line.SetPosition(0, position);
        line.SetPosition(countStep, position);
        for (int currentStaep = 1; currentStaep <= countStep - 1; currentStaep++)
        {
            float radian = ((float)currentStaep / countStep) * angel * Mathf.Deg2Rad + direct * Mathf.Deg2Rad - angel/2 * Mathf.Deg2Rad;
            float height = t.GetHeightDot(new Vector2(Mathf.Cos(radian) * radius + position.x, Mathf.Sin(radian) * radius + position.z)) + 0.1f;
            line.SetPosition(currentStaep, new Vector3(Mathf.Cos(radian) * radius + position.x, 
                                                        height, 
                                                        Mathf.Sin(radian) * radius + position.z));
        }
    }
}
