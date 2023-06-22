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
        {"Parallel Move", new ParalelMove() },
        {"Dodge Cirñle", new DodgeCircle() },
        {"Dodge Sector", new DodgeSector() },
        {"Angel Dodge", new DodgeAngle() },
        {"Wolf", new WolfHunter() },
    };

    public static List<string> GetNames()
    {
        List<string> list = new List<string>();
        foreach (string name in logicsMove.Keys)
        {
            list.Add(name);
        }
        return list;
    }

    public static ILogicMove GetElemetByName(string name)
    {
        return logicsMove[name];
    }
}
