using System;
using UnityEngine;

public class Island
{
    public string[] attachedBallsIds;
}

public class Force
{
    public string id;

    public float power;
    public Vector3 direction;

    public string[] affectedMaterials;
}

public class Joint
{
    public string id;

    public string[] attachedBallsIds;
    public float strength;
    public float maxRange;
    public float stretchiness;
}

public class Material
{
    public float weight;
    public float elasticity;
    public float softness;
    public float durability;
}

public enum Shape
{
    None, Ball, Pyramid, Cube
}

public class Ball
{
    public string id;

    public Vector3 position;
    public float radius;

    public Shape innerShape;
    public Quaternion rotation;
    
    public float maxRestingSpeed;
    public bool isResting;
    
    // one of applied forces instead
    // public Vector3 gravityEffect;
    
    // runtime vars
    public Vector3 acceleration;
    public Vector3 velocity;

    public Vector3 squishVector; // or stretch
    public float squishPower;

    public string[] appliedForcesIds;
    
    public Ball()
    {
        id = Guid.NewGuid().ToString();
    }
}
