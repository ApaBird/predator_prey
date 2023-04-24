using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    private float speed;
    private Vector2 nowDirection;
    private Vector2 wantDirection;
    private float turnSpeed;
    private float radius;
    private Vector2 position;
    private float angelDetection;
    private List<Creature> visibleCreature;
    private ILogicMove logicMove;
    public float Speed { get => speed; }
    public Vector2 NowDirection { get => nowDirection; }
    public Vector2 WantDirection { get => wantDirection; }
    public float TurnSpeed { get => turnSpeed; }
    public float Radius { get => radius; }
    public Vector2 Position { get => position; }
    public ILogicMove LogicMove { get => logicMove; }
    public float AngelDetection { get => angelDetection; }
    public List<Creature> VisibleCreature { get => visibleCreature; set => visibleCreature = value; }

    public Creature(Vector2 pos, Vector2 direction, float turn, float r, ILogicMove move, float sp, float angel) { 
        this.logicMove = move;
        this.speed = sp;
        this.position = pos;
        this.turnSpeed = turn;
        this.radius = r;
        this.position = pos;
        this.nowDirection = direction;
        this.angelDetection = angel;
        this.visibleCreature = new List<Creature>();
    }

    public void Step()
    {
        wantDirection = logicMove.Direction(this);
        wantDirection.Normalize();
        if (nowDirection.normalized != wantDirection.normalized)
        {
            float basisRotation = Vector2.Angle(wantDirection, Vector2.right) * Mathf.Deg2Rad;
            Vector2 localNowDirection = new Vector2(
                nowDirection.x * Mathf.Cos(basisRotation) + nowDirection.x * Mathf.Sin(basisRotation),
                -nowDirection.x * Mathf.Sin(basisRotation) + nowDirection.y * Mathf.Cos(basisRotation));

            float angel = Vector2.Angle(wantDirection, nowDirection);
            //Debug.Log(angel);
            if (Mathf.Abs(angel) > turnSpeed)
            {
                angel = ((localNowDirection.y > 0)?-turnSpeed: turnSpeed) * Mathf.Deg2Rad;
                nowDirection.x = nowDirection.x * Mathf.Cos(angel) - nowDirection.y * Mathf.Sin(angel);
                nowDirection.y = nowDirection.x * Mathf.Sin(angel ) + nowDirection.y * Mathf.Cos(angel);
                nowDirection.Normalize();
            }
            else
            {
                nowDirection = wantDirection;
            }
        }
        position += nowDirection * speed;
    }

    public bool InFieldOfDetection(Creature target)
    {
        return new Vector2(this.position.x - target.Position.x, this.position.y - target.Position.y).magnitude < this.radius;
    }
}
