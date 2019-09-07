using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship{

	public string name;
	public Point position;

	protected string _spritePath;
	protected GameObject _instance = new GameObject();
	protected SpriteRenderer _renderer = new SpriteRenderer();

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
	}

	public void Update(){

		_instance.transform.position = new Vector3(position.x, position.y, 0);
	}
}

public struct Point{

	public float x;
	public float y;

	public Point(float x, float y){

		this.x = x;
		this.y = y;
	}
}