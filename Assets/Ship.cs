using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship{

	public string name;
	public Vec2 position;
	public Vec2 acceleration;

	protected string _spritePath;
	protected GameObject _instance = new GameObject();
	protected SpriteRenderer _renderer = new SpriteRenderer();

	private Vec2 _velocity = new Vec2(0,0);
	private float _maxVelocity = 1;

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

		acceleration = new Vec2(0.005f, 0);
	}

	public void Update(){

		_velocity += acceleration;

		Vec2.Clamp(ref _velocity, 0, _maxVelocity);

		position += _velocity;

		Debug.Log(_velocity.x);

		_instance.transform.position = new Vector3(position.x, position.y, 0);
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