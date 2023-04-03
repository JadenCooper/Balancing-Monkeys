using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 PlayerScores = new Vector2(0, 0);
    public Vector2 bananaXSpawnConfines;
    public Vector2 bananaYSpawnConfines;
    public GameObject banana;
    public int MaxBananas = 5;
    private void Start()
    {
        for (int i = 0; i < MaxBananas; i++)
        {
            SpawnBanana();
        }
    }
    public void ChangeScore(float scoreChange, string TeamTag)
    {
        if (TeamTag == "TeamOne")
        {
            PlayerScores.x += scoreChange;
        }
        else
        {
            PlayerScores.y += scoreChange;
        }
    }

    public void SpawnBanana()
    {
        Vector3 SpawnPoint = new Vector3(Random.Range(bananaXSpawnConfines.x, bananaXSpawnConfines.y), Random.Range(bananaYSpawnConfines.x, bananaYSpawnConfines.y), 0);
        Instantiate(banana, SpawnPoint, Quaternion.identity);
        banana.GetComponent<Banana>().gameManager = this;
    }
}
