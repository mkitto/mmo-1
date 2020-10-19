using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : Unit
{
	public float forceCoef;
	public UnityAction<int> OnScore;
	
	public Slider slider;

	// Update is called once per frame
	public override void OnUpdate()
	{

		slider.value = Mathf.Lerp(slider.value,  HP,  1.0f);

		Vector2 pos = this.transform.position;
		pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
		this.transform.position = pos;

		if (Input.GetButton("Fire1"))
        {
			this.Fire();
        }
	}

	public void Init()
    {
		this.transform.position = _initPos;
		this.Idle();
		this._death = false;
		HP = 100;
		slider.value = HP;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Bullet bullet = col.gameObject.GetComponent<Bullet>();
		Enemy enemy = col.gameObject.GetComponent<Enemy>();
		if (bullet)
        {
			if (bullet.side == SIDE.ENEMY)
			{
				this.HP -= bullet.power;
				if (this.HP <= 0)
				{
					this.Die();
				}
			}
		}

		if (enemy && enemy.side == SIDE.ENEMY)
		{
			this.HP = 0;
			this.Die();
		}

		Debug.Log("Player: OnTriggerEnter2D " + col.gameObject.name);
		
	}

	void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log("Player: OnTriggerExit2D " + col.gameObject.name);
		if (col.gameObject.name.Equals("ScoreArea"))
		{
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("Player: OnCollisionEnter2D " + col.gameObject.name);
	}
}