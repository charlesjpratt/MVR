using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMananger : MonoBehaviour
{
    public Ship player;

    // Start is called before the first frame update
    void Start() {
        
        player = new Ship(0.05f, 0.045f, 0.007f, "Player Ship", "ship");
        player.Initialize(0,-3,true);

        // bullet = new Bullet(0, -3, "Bullet", "player_bullet");
        // bullet.Initialize(0.075f, 0.1f, 0);
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

    	if(Input.GetKeyDown(KeyCode.Space)){

    		player.Fire();
    	}

       player.Update();
    }
}
