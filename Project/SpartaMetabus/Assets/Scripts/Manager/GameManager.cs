using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static Vector3 playerLastPos;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]private Player player;
    public Player Player { get { return player; } }

    void Start()
    {
        player.Init();
        SetPlayerPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerPos()
    {
        player.transform.position = playerLastPos;
    }

    public void SaveLastPos()
    {
        playerLastPos = player.transform.position;
    }
}
