using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRender : MonoBehaviour
{
    public static void DrawCircle(float radius, Vector3 position, LineRenderer line, Terrain t)
    {
        int countStep = 100;
        line.positionCount = countStep + 1;

        for(int currentStaep = 0; currentStaep <= countStep; currentStaep++)
        {
            float radian = ((float)currentStaep / countStep) * 2 * Mathf.PI;
            float height = t.GetHeightDot(new Vector2(Mathf.Cos(radian) * radius + position.x, Mathf.Sin(radian) * radius + position.z)) + 0.1f;
            line.SetPosition(currentStaep, new Vector3(Mathf.Cos(radian) * radius + position.x, height, Mathf.Sin(radian) * radius + position.z));
        }
    }
}
