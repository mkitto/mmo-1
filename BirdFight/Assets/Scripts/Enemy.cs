using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit {
	public event DeathNotify OnDeath;
	public ENEMY_TYPE enemyType;
	public float lifeTime;

	public Vector2 range;
	private float _initY;

	// Use this for initialization
	void Start()
	{
		this.ani = this.GetComponent<Animator>();
		Fly();
		Destroy(this.gameObject, lifeTime);

		_initY = Random.Range(range.x, range.y);
		this.transform.localPosition = new Vector3(0, _initY, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (this._death)
			return;

		fireTimer += Time.deltaTime;
		float y = 0;
		if (enemyType == ENEMY_TYPE.SWING)
        {
			y = Mathf.Sin(Time.timeSinceLevelLoad * 10f) * 2;
        }

		this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed, _initY + y, 0);

		Fire();
	}

	public new void Fire()
	{
		if (fireTimer > 1.0 / fireRate)
		{
			GameObject bullet = Instantiate(bulletTemplate);
			bullet.transform.position = this.transform.position;
			bullet.GetComponent<Bullet>().direction = -1;
			fireTimer = 0.0f;
		}
	}

	public void Init()
	{
		this.Fly();
		this._death = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Bullet bullet = col.gameObject.GetComponent<Bullet>();
		if (!bullet)
		{
			return;
		}
		Debug.Log("Enemy: OnTriggerEnter2D " + col.gameObject.name);
		if (bullet.side == SIDE.PLAYER)
		{
			this.Die();
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log("Enemy: OnTriggerExit2D " + col.gameObject.name);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("Enemy: OnCollisionEnter2D " + col.gameObject.name);
	}

	public override void Die()
	{
		this._death = true;
		this.ani.SetTrigger("Die");
		if (this.OnDeath != null)
		{
			this.OnDeath();
		}
		Destroy(this.gameObject, 0.15f);
	}
}
