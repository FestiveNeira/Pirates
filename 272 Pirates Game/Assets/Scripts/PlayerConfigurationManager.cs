using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int MaxPlayers = 4;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("trying to make another instance of singlton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public void SetPlayer1Prefab(int index)
    {
        playerConfigs[index].active = true;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if(playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("Supermarket Level");
        }
    }

    public void HadlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("player joined " + pi.playerIndex);
    }
}

public class PlayerConfiguration
{
    public PlayerInput input { get; set; }

    public int playerIndex { get; set; }
    public bool isReady { get; set; }
    public bool active { get; set; }
}
