using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public List<Ball> balls = new List<Ball>();

    public void AddBall()
    {
        balls.Add(new Ball());
    }
    
}
