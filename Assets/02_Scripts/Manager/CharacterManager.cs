using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterManager : Singleton<ChracterManager> 
{
    public Player player;

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
