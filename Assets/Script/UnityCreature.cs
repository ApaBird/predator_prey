using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnityCreature : MonoBehaviour
{
    [SerializeField] private LineRenderer lineZone;
    [SerializeField] private VectorRender lineNowDirect;
    [SerializeField] private VectorRender lineWantDirect;
    [SerializeField] private LineRenderer traectory;

    [SerializeField] private Parametr speed = new Parametr("Скорость", 1);
    [SerializeField] private Parametr turnSpeed = new Parametr("Скорость поворота", 5);
    [SerializeField] private Parametr radius = new Parametr("Радиус", 1);
    [SerializeField] private Parametr positionX = new Parametr("Позиция по X", 0);
    [SerializeField] private Parametr positionY = new Parametr("Позиция по Y", 0);
    [SerializeField] private Parametr startpositionX = new Parametr("Позиция по X", 0);
    [SerializeField] private Parametr startpositionY = new Parametr("Позиция по Y", 0);
    [SerializeField] private Parametr directionAngel = new Parametr("Угол направления", 0);
    [SerializeField] private Parametr startDirectionAngel = new Parametr("Угол направления", 0);
    [SerializeField] private Parametr angelDetection = new Parametr("Угол обзора", 360);
    [SerializeField] private ParametrList logicMove = new ParametrList("Алгоритм движения", LogicMoveLocator.GetNames());
    [SerializeField] private ParametrList methodDetection = new ParametrList("Зона обнаружения", MethodDetectionLocator.GetNames());
    [SerializeField] private Parametr typeCreature = new Parametr("Тег", 1);
    [SerializeField] private Parametr height = new Parametr("Высота", 1);
    private Creature creature = null;

    public Parametr Speed { get => speed; set => speed = value; }
    public Parametr TurnSpeed { get => turnSpeed; set => turnSpeed = value; }
    public Parametr Radius { get => radius; set => radius = value; }
    public Parametr PositionX { get => positionX; }
    public Parametr PositionY { get => positionY; }
    public Parametr DirectionAngel { get => directionAngel; }
    public Parametr StartpositionX { get => startpositionX; set => startpositionX = value; }
    public Parametr StartpositionY { get => startpositionY; set => startpositionY = value; }
    public Parametr AngelDetection { get => angelDetection; set => angelDetection = value; }
    public Parametr StartDirectionAngel { get => startDirectionAngel; set => startDirectionAngel = value; }
    public ParametrList LogicMove { get => logicMove; set => logicMove = value; }
    public Parametr Height { get => height; set => height = value; }
    public ParametrList MethodDetection { get => methodDetection; set => methodDetection = value; }
    public LineRenderer LineZone { get => lineZone; }
    public Creature Creature { get => creature; }
    public Parametr TypeCreature { get => typeCreature; set => typeCreature = value; }

    public Creature StartSimulation(Terrain tr)
    {
        return StartSimulation(tr, creature);
    }

    public Creature StartSimulation(Terrain tr, Creature creature)
    {
        positionX.value = startpositionX.value;
        positionY.value = startpositionY.value;
        directionAngel.value = startDirectionAngel.value;
        Vector2 direction = new Vector2(Mathf.Cos(startDirectionAngel.value * Mathf.Deg2Rad), Mathf.Sin(startDirectionAngel.value * Mathf.Deg2Rad));
        this.creature = new Creature(new Vector2(startpositionX.value, startpositionY.value), direction,
                                TurnSpeed.value, Radius.value, LogicMoveLocator.GetElemetByName(logicMove.selected),
                                Speed.value, AngelDetection.value, tr, MethodDetectionLocator.GetElemetByName(methodDetection.selected));
        this.creature.Tag = (int)typeCreature.value;
        traectory.positionCount = 0;
        return this.creature;
    }

    public void StopSimulation()
    {
        creature = null;
    }

    public List<Parametr> GetSimulationInfoParametrs()
    {
        return new List<Parametr>() { Speed, TurnSpeed, PositionX, PositionY, DirectionAngel, Radius, AngelDetection };
    }

    public List<ParametrList> GetSimulationInfoParametrsList()
    {
        return new List<ParametrList>() {LogicMove};
    }

    public List<Parametr> GetInfoParametrs()
    {
        return new List<Parametr>() { Speed, TurnSpeed, StartpositionX, StartpositionY, StartDirectionAngel, Radius, AngelDetection, TypeCreature };
    }

    public List<ParametrList> GetInfoParametrsList()
    {
        return new List<ParametrList>() { LogicMove, MethodDetection};
    }

    public void Start()
    {
        startpositionX.value = transform.position.x;
        startpositionY.value = transform.position.z;
        startDirectionAngel.value = transform.eulerAngles.y;
    }

    public void Update()
    {
        if (creature == null)
        {
            transform.position = new Vector3(startpositionX.value, height.value, startpositionY.value);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -startDirectionAngel.value, transform.eulerAngles.z);

            if (lineNowDirect != null)
                lineNowDirect.DrawVector(new Vector2(Mathf.Cos(startDirectionAngel.value * Mathf.Deg2Rad), Mathf.Sin(startDirectionAngel.value * Mathf.Deg2Rad)), transform.position, 10);
        }
        else
        {
            positionX.value = creature.Position.x;
            positionY.value = creature.Position.y;
            height.value = creature.Height;
            if (creature.NowDirection.y > 0)
            {
                directionAngel.value = Mathf.Acos(creature.NowDirection.x) * Mathf.Rad2Deg;
            }
            else
            {
                directionAngel.value = -Mathf.Acos(creature.NowDirection.x) * Mathf.Rad2Deg;
            }
            //Включить отрисовку траектории
            if(traectory != null)
            {
                traectory.positionCount++;
                traectory.SetPosition(traectory.positionCount - 1, this.gameObject.transform.position);
            }

            transform.position = new Vector3(positionX.value, creature.Height + 0.1f, positionY.value);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -directionAngel.value, transform.eulerAngles.z);

            if (lineWantDirect != null)
                lineWantDirect.DrawVector(creature.WantDirection, transform.position, 10);
            if (lineNowDirect != null)
                lineNowDirect.DrawVector(creature.NowDirection, transform.position, 10);
            MethodDetectionLocator.GetElemetByName(methodDetection.selected).DrawZone(this);
        }

        
    }
}
