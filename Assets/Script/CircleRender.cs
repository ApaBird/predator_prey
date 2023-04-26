using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRender : MonoBehaviour
{
    [SerializeField] private LineRenderer line;

    public void DrawCircle(float radius, Vector3 position)
    {
        int countStep = 100;
        line.positionCount = countStep + 1;

        for(int currentStaep = 0; currentStaep <= countStep; currentStaep++)
        {
            float radian = ((float)currentStaep / countStep) * 2 * Mathf.PI;

            line.SetPosition(currentStaep, new Vector3(Mathf.Cos(radian) * radius + position.x, position.y, Mathf.Sin(radian) * radius + position.z));
        }
    }
}
