using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class ControlSystemOfSimulation
{
    private List<Creature> creatures;
    private bool pause = false;
    private TimerCallback tm;
    private Terrain terrain;

    public bool Pause { get => pause; set => pause = value; }

    public ControlSystemOfSimulation(int speedSimulation, Terrain tr, List<Creature> creature = null, bool pause = true) {
        if (creature == null)
            this.creatures = new List<Creature>();
        else
            this.creatures = creature;//должен копировать а не присваивать

        this.pause = pause;

        terrain = tr;

        tm = new TimerCallback(Step);//создавать экземпляр делегата прямо тут
        Timer timer = new Timer(tm, null, 0, speedSimulation);//добавить отдельное поле скорости симуляции и записывать в поле таймер для будущего изменения.
    }

    public void StepSimulation()
    {
        foreach (Creature creature in creatures)
            creature.Step();

        foreach (Creature creature in creatures){
            foreach (Creature target in creatures){
                if(creature != target)
                {
                    creature.InFieldOfDetection(target);
                }
            }
        }
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
    //еще нужен метод для удаления существ из списка

    //метод для изменения карты

    //метод для смены скорости симуляции

    public List<Creature> GetCreatures() => creatures;
}
