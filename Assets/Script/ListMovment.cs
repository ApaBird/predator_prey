using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListMovment
{
    private static Dictionary<string, ILogicMove> listMovment = new Dictionary<string, ILogicMove>();

    public static ILogicMove GetLogicMove(string id)
    {
        return listMovment[id];
    }
}
