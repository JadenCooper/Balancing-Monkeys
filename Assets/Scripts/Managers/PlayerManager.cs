using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Vector3[] spawnPoints = new Vector3[2];
    [SerializeField]
    private List<PlayerControler> monkeyList = new List<PlayerControler>();
    private PlayerInput playerInput;
    public GameObject monkeyPrefab;
    public int currentPlayerIndex = 0;
    public int MonkeyTeamLeft = 5;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        SwitchPlayer();
    }

    public void SwitchPlayer()
    {
        GameObject newMonkey = Instantiate(monkeyPrefab, spawnPoints[currentPlayerIndex], Quaternion.identity);
        playerInput.currentPlayer = newMonkey.GetComponent<PlayerControler>(); // Sets The PlayerInput To Interact With The New Spawned Monkey
        if (currentPlayerIndex == 0)
        {
            // Changes Which Team THe Monkey Is Spawning For Next Spawn
            currentPlayerIndex++;
        }
        else
        {
            currentPlayerIndex--;
            MonkeyTeamLeft--; // If We End Up Having A Monkey Life Limit
            Debug.Log(MonkeyTeamLeft);
            if (MonkeyTeamLeft == 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

}
