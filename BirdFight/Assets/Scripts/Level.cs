using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public int LevelID;
	public string Name;

	public Boss Boss;

	public List<SpawnRule> Rules = new List<SpawnRule>();

	float bossTime = 60f;

	float timer = 0;

	float timeSinceLevelStart = 0;

	float levelStartTime = 0;

	Boss boss = null;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Rules.Count;  i++)
        {
			SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;
		if (timeSinceLevelStart > bossTime)
        {
			if (boss == null)
            {
				boss = (Boss)UnitManager.Instance.CreateEnemy(this.Boss.gameObject);
				Player player = Game.Instance.player;
				boss.target = player;
			}
        }
	}
}
