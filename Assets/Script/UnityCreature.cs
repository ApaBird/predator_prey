using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCreature : MonoBehaviour
{
    [SerializeField] private Parametr speed = new Parametr("��������", 1);
    [SerializeField] private Parametr turnSpeed = new Parametr("�������� ��������", 5);
    [SerializeField] private Parametr radius = new Parametr("������", 1);
    [SerializeField] private Parametr positionX = new Parametr("������� �� X", 0);
    [SerializeField] private Parametr positionY = new Parametr("������� �� Y", 0);
    [SerializeField] private Parametr startpositionX = new Parametr("������� �� X", 0);
    [SerializeField] private Parametr startpositionY = new Parametr("������� �� Y", 0);
    [SerializeField] private Parametr directionAngel = new Parametr("���� �����������", 0);
    [SerializeField] private Parametr angelDetection = new Parametr("���� ������", 360);
    [SerializeField] private ILogicMove logicMove = new SimpleMove();
    private Creature creature = null;

    public Parametr Speed { get => speed; set => speed = value; }
    public Parametr TurnSpeed { get => turnSpeed; set => turnSpeed = value; }
    public Parametr Radius { get => radius; set => radius = value; }
    public ILogicMove LogicMove { get => logicMove; set => logicMove = value; }
    public Parametr PositionX { get => positionX; set => positionX = value; }
    public Parametr PositionY { get => positionY; set => positionY = value; }
    public Parametr DirectionAngel { get => directionAngel; set => directionAngel = value; }
    public Parametr StartpositionX { get => startpositionX; set => startpositionX = value; }
    public Parametr StartpositionY { get => startpositionY; set => startpositionY = value; }
    public Parametr AngelDetection { get => angelDetection; set => angelDetection = value; }

    public Creature StartSimulation()
    {
        positionX.value = startpositionX.value;
        positionY.value = startpositionY.value;
        Vector2 direction = new Vector2(Mathf.Cos(directionAngel.value * Mathf.Deg2Rad), Mathf.Sin(directionAngel.value * Mathf.Deg2Rad));
        creature = new Creature(new Vector2(startpositionX.value, startpositionY.value), direction, TurnSpeed.value, Radius.value, this.logicMove, Speed.value, AngelDetection.value);
        return creature;
    }

    public void StopSimulation()
    {
        creature = null;
    }


    public List<Parametr> Info()
    {
        return new List<Parametr>() { Speed, TurnSpeed, StartpositionX, StartpositionY, DirectionAngel, Radius, AngelDetection }; ;
    }

    public void Start()
    {
        startpositionX.value = transform.position.x;
        startpositionY.value = transform.position.z;
        directionAngel.value = transform.eulerAngles.y;
    }

    public void Update()
    {
        if (creature == null)
        {
            transform.position = new Vector3(startpositionX.value, transform.position.y, startpositionY.value);
        }
        else
        {
            positionX.value = creature.Position.x;
            positionY.value = creature.Position.y;
            if (creature.NowDirection.y > 0)
            {
                directionAngel.value = Mathf.Acos(creature.NowDirection.x) * Mathf.Rad2Deg;
            }
            else if (creature.NowDirection.x > 0)
            {
                directionAngel.value = -Mathf.Acos(creature.NowDirection.x) * Mathf.Rad2Deg;
            }
            //�������� ��������� ����������
            //Instantiate<GameObject>(this.gameObject).GetComponent<UnityCreature>().enabled = false;

            transform.position = new Vector3(positionX.value, transform.position.y, positionY.value);
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, -directionAngel.value, transform.eulerAngles.z);
    }
}
