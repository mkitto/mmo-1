using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  负责刷怪
 */
public class SpawnRule : MonoBehaviour {

	public float InitTime;

	public Unit Monster;
	public int MaxNum;
	public float Period;
	public int HP;
	public int Attack;

	float timeSinceLevelStart = 0;

	float levelStartTime = 0;

	int num = 0;
	float timer = 0;

	// Use this for initialization
	void Start () {
		this.levelStartTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;
		if (num >= MaxNum) return;
		if(timeSinceLevelStart > InitTime)
        {
			//开始刷怪
			timer += Time.deltaTime;

			if (timer > Period)
            {
				timer = 0;
				Enemy enemy= UnitManager.Instance.CreateEnemy(this.Monster.gameObject);
				enemy.MaxHp = this.HP;
				enemy.Attack = this.Attack;
				num++;
			}
		}
	}
}
