using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship{

	public string name;
	public Vec2 position;
	public float acceleration;
	public float friction;

	protected string _spritePath;
	protected GameObject _instance = new GameObject();
	protected SpriteRenderer _renderer = new SpriteRenderer();

	private Vec2 _velocity = new Vec2(0,0);
	private float _maxVelocity = 0.045f;

	public enum Direction { RIGHT, LEFT, UP, DOWN }

	public Ship(float x, float y, string name, string path){

		position.x = x;
		position.y = y;

		this.name = name;
		_spritePath = path;
	}

	public void Initialize(){

		_instance.AddComponent<SpriteRenderer>();
		_renderer = _instance.GetComponent<SpriteRenderer>();

		_renderer.sprite = Resources.Load<Sprite>(_spritePath);

		_instance.name = name;

		acceleration = 0.05f;
		friction = 0.007f;
	}

	public void Update(){

		Vec2.Clamp(ref _velocity, -_maxVelocity, _maxVelocity);

		ApplyFriction();

		Debug.Log(_velocity.x);

		position += _velocity;

		_instance.transform.position = new Vector3(position.x, position.y, 0);
	}

	public void Move(Direction direction){

		switch(direction){

			case Direction.LEFT: _velocity.x -= acceleration; break;
			case Direction.RIGHT: _velocity.x += acceleration; break;
		}
	}

	private void ApplyFriction(){

		if(_velocity.x < 0){ _velocity.x += friction; }
		if(_velocity.x > 0){ _velocity.x -= friction; }

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