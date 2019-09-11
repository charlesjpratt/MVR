using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Von
{

	public string name;
	public Vec2 position = new Vec2(999, 999);

	public bool active;
	
	protected GameObject _instance = new GameObject();
	protected SpriteRenderer _renderer = new SpriteRenderer();

	protected Vec2 _velocity = new Vec2(0,0);

	protected float _acceleration;
	protected float _friction;
	protected float _maxVelocity = 0.045f;

	public enum Direction { RIGHT, LEFT, UP, DOWN }

	public Von(float acceleration, float maxVelocity, float friction, string name, string path){

		_instance.AddComponent<SpriteRenderer>();
		_renderer = _instance.GetComponent<SpriteRenderer>();

		_renderer.sprite = Resources.Load<Sprite>(path);

		_instance.name = name;

		_acceleration = acceleration;
		_maxVelocity = maxVelocity;
		_friction = friction;

		this.name = name;
	}

	public virtual void Update(){ 

		if(active){

			ApplyFriction();
			UpdatePosition();
		}
		else{

			position.x = 999f;
			position.y = 999f;
		}
	}
	public virtual void Initialize(float x, float y, bool active){ 

		this.active = active;

		position.x = x;
		position.y = y;

		UpdateInstance();
	}
	
	public virtual void Move(Direction direction){ 

		switch(direction){

			case Direction.LEFT: _velocity.x -= _acceleration; break;
			case Direction.RIGHT: _velocity.x += _acceleration; break;
			case Direction.UP: _velocity.y += _acceleration; break;
		}
	}

	protected void UpdateInstance(){

		_instance.transform.position = new Vector3(position.x, position.y, 0);
	}

	private void UpdatePosition(){

		Vec2.Clamp(ref _velocity, -_maxVelocity, _maxVelocity);

		ApplyFriction();

		//Debug.Log(_velocity.x);

		position += _velocity;

		_instance.transform.position = new Vector3(position.x, position.y, 0);
	}

	private void ApplyFriction(){

		if(_velocity.x < 0){ _velocity.x += _friction; }
		if(_velocity.x > 0){ _velocity.x -= _friction; }

		if(Mathf.Abs(_velocity.x) < 0.01){ _velocity.x = 0; }
	}   
}

public struct Vec2{

	public float x;
	public float y;

	public Vec2(float x, float y){

		this.x = x;
		this.y = y;
	}

	public static void Clamp(ref Vec2 vec, float min, float max){

		if(vec.x > max){ vec.x = max; }
		if(vec.y > max){ vec.y = max; }
		if(vec.x < min){ vec.x = min; }
		if(vec.y < min){ vec.y = min; }


	}

	public static Vec2 operator +(Vec2 a, Vec2 b){

		return new Vec2(a.x + b.x, a.y + b.y);
	}
}
