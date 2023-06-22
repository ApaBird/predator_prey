using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHunter : ILogicMove
{
    public Vector2 Direction(Creature creature)
    {
        if (creature.VisibleCreature.Count != 0)
        {
            List<Creature> targets = new List<Creature>();
            List<Creature> team = new List<Creature>();
            foreach (Creature target in creature.VisibleCreature)
            {
                if(target.Tag != creature.Tag) targets.Add(target);
                else team.Add(target);
            }
            if(targets.Count > 0)
                for(int i = 0; i < targets.Count; i++)
                {
                    Creature myTarget = null;
                    float minDistan = creature.Radius;
                    foreach (Creature target in targets)
                    {
                        if((target.Position - creature.Position).magnitude < minDistan)
                        {
                            myTarget = target;
                            minDistan = (target.Position - creature.Position).magnitude;
                        }
                    }

                    if(myTarget != null)
                        foreach(Creature allied in team)
                        {
                            if((myTarget.Position - allied.Position).magnitude < minDistan)
                            {
                                myTarget = null;
                                break;
                            }
                        }

                    if(myTarget != null)
                        return myTarget.Position - creature.Position;
                }
            return creature.NowDirection;
        }
        else
            return creature.NowDirection;
    }

    public string GetName()
    {
        return "Групповая охота";
    }
}
