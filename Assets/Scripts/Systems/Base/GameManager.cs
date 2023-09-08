using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Rect playingField;
    public Rect deleteBound;

    public int playerLives;
    public int playerBombs;
    public float hyperCharge;

    public ulong score;

    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
