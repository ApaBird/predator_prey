using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityControlSimulation : MonoBehaviour
{
    private ControlSystemOfSimulation model;
    [SerializeField] List<UnityCreature> creatures;
    [SerializeField] float speedSimulation = 1;
    [SerializeField] UIBar bar;
    private bool newSimulation = true;
    private UnityCreature selectCreature;
    private Camera camera;

    public void StartSimulation()
    {
        foreach(UnityCreature creature in creatures) {
            model.AddCreature(creature.StartSimulation());
        }
        Debug.Log(selectCreature);
        if (selectCreature != null)
        {
            bar.SetCreature(selectCreature, !newSimulation);
        }
    }

    public void StartStop()
    {
        model.Pause = !model.Pause;
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
        model = new ControlSystemOfSimulation((int)(speedSimulation * 1000) ,null, false);
        foreach (UnityCreature creature in creatures)
        {
            creature.StopSimulation();
        }
        newSimulation = true;
        model.Pause = true;
    }

    private void Start()
    {
        Restart();
        camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<UnityCreature>() != null)
                {
                    selectCreature = hit.collider.gameObject.GetComponent<UnityCreature>();
                    bar.SetCreature(selectCreature, !newSimulation);
                }
            }
        }
    }
}
