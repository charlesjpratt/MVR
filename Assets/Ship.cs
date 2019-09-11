using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Von{

	private Bullet bullet;

	public Ship(float acceleration, float maxVelocity, float friction, string name, string path) : base(acceleration,maxVelocity,friction,name,path){ }

	public override void Initialize(float x, float y, bool active) {

		base.Initialize(x, y, active);

		bullet = new Bullet(0.075f,0.1f,0,"Player Bullet","player_bullet");
		bullet.Initialize(999, 999, false);
	}

	public override void Update(){

		base.Update();
		bullet.Update();
	}

	public void Fire(){

		if(bullet.active == false){

			bullet.position = this.position;
			bullet.active = true;	
		}
	}
}