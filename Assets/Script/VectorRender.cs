using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorRender : MonoBehaviour
{
    [SerializeField] private LineRenderer line;

    public void DrawVector(Vector2 vector, Vector3 position, float length)
    {
        line.positionCount = 2;
        line.SetPosition(0, position);
        line.SetPosition(1, new Vector3(position.x + vector.x * length, position.y, position.z + vector.y * length));
    }
}
