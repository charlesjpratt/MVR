using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMananger : MonoBehaviour
{
    public Ship player;

    // Start is called before the first frame update
    void Start() {
        
        player = new Ship(0,0, "Player Ship", "ship");
        player.Initialize();

    }

    // Update is called once per frame
    void Update() {
       
       player.Update();

    }
}
