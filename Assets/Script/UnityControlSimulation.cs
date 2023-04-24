using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityControlSimulation : MonoBehaviour
{
    private ControlSystemOfSimulation model;
    [SerializeField] List<UnityCreature> creatures;
    [SerializeField] bool pause;
    [SerializeField] float speedSimulation = 1;
    private float timeLastStep = 0;
    private bool newSimulation = true;

    public void StartSimulation()
    {
        foreach(UnityCreature creature in creatures) {
            model.AddCreature(creature.StartSimulation());
        }
    }

    public void StartStop()
    {
        pause = !pause;
        if (newSimulation)
        {
            StartSimulation();
            newSimulation = false;
        }
    }

    public void NextStep()
    {
        model.StepSimulation();
    }

    public void Restart()
    {
        model = new ControlSystemOfSimulation(null, false);
        pause = model.Pause;
        newSimulation = true;
    }

    private void Start()
    {
        Restart();
    }

    private void Update()
    {
        if (!pause && Time.time - timeLastStep > speedSimulation)
        {
            NextStep();
            timeLastStep = Time.time;
        }
    }

}
