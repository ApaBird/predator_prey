using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodDetectionLocator : MonoBehaviour
{
    private static Dictionary<string, IZoneDetection> methodsDetection = new Dictionary<string, IZoneDetection>()
    {
        {"����������", new CircleZone() },
        {"������", new SectorZone() },
        {"����", new AngelDetection() },
    };

    public static List<string> GetNames()
    {
        List<string> list = new List<string>();
        foreach (string name in methodsDetection.Keys)
        {
            list.Add(name);
        }
        return list;
    }

    public static IZoneDetection GetElemetByName(string name)
    {
        return methodsDetection[name];
    }
}
