using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Rect playingField;
    public Rect deleteBound;

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

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,1);
        Gizmos.DrawWireCube(playingField.center, new Vector3(playingField.width, playingField.height, 1));
    }
}
