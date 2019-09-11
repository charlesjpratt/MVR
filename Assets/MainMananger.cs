using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMananger : MonoBehaviour
{
    public Ship player;

    // Start is called before the first frame update
    void Start() {
        
        player = new Ship(0,-3, "Player Ship", "ship");
        player.Initialize();

    }

    // Update is called once per frame
    void Update() {
       
    	if(Input.GetKey(KeyCode.LeftArrow)){

    		player.Move(Ship.Direction.LEFT);
    		//Debug.Log("Left Pressed!");
    	}
    	if(Input.GetKey(KeyCode.RightArrow)){

    		player.Move(Ship.Direction.RIGHT);
    		//Debug.Log("Right Pressed!");
    	}

       player.Update();
    }
}
