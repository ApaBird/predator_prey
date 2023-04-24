using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class ControlSystemOfSimulation
{
    private List<Creature> creatures;
    private bool pause = false;
    private TimerCallback tm;

    public bool Pause { get => pause; set => pause = value; }

    public ControlSystemOfSimulation(List<Creature> creature = null, bool pause = true) {
        if (creature == null)
            this.creatures = new List<Creature>();
        else
            this.creatures = creature;

        this.pause = pause;

        tm = new TimerCallback(Step);
        Timer timer = new Timer(tm, null, 0, 100);
    }

    public void StepSimulation()
    {
        foreach (Creature creature in creatures)
            creature.Step();
    }

    public void Step(object _)
    {
        if (!pause)
        {
            StepSimulation();
        }
    }

    public void AddCreature(Creature creature) {
        creatures.Add(creature);
    }

    public List<Creature> GetCreatures() => creatures;
}