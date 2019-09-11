using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Von
{

	public Bullet(float acceleration, float maxVelocity, float friction, string name, string path) : base(acceleration,maxVelocity,friction,name,path){ }

	public override void Update(){

		if(active){ Move(Von.Direction.UP); }

		if(position.y > 7.5f){ 

			active = false;

			position.x = 999;
			position.y = 999;

			UpdateInstance();
		}

		base.Update();
	} 
}
