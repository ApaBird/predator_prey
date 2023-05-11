using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogicMoveLocator 
{
    private static Dictionary<string, ILogicMove> logicsMove = new Dictionary<string, ILogicMove>() 
    {
        {"Simple Move", new SimpleMove() },
        {"Predict Move", new PreemptionMove() },
        {"Forward Move", new ForwardMove() },
    };

    public static List<string> GetNameLogicMove()
    {
        List<string> list = new List<string>();
        foreach (string name in logicsMove.Keys)
        {
            list.Add(name);
        }
        return list;
    }

    public static ILogicMove GetLogicMoveByName(string name)
    {
        return logicsMove[name];
    }
}
