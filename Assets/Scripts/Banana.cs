using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Pickup
{
    public float Score = 10;
    public GameManager gameManager;
    public override void PreformPickUp()
    {
        Debug.Log(Score + " Score Gained");
        gameManager.ChangeScore(Score, tag);
        Destroy(gameObject);
    }
}
