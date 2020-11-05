using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour {

	public int LevelID;
	public string Name;

	public Boss Boss;

	public List<SpawnRule> Rules = new List<SpawnRule>();

	public float bossTime = 1f;

	float timeSinceLevelStart = 0;

	public float levelStartTime = 0;

	Boss boss = null;

	private List<SpawnRule> instanceRules = new List<SpawnRule>();
	public enum LEVEL_RESULT
    {
		NONE,
		SUCCESS,
		FAIL
    };

	LEVEL_RESULT result = LEVEL_RESULT.NONE;

	public UnityAction<LEVEL_RESULT> OnLevelEnd;

	public void ClearData()
    {

		foreach (SpawnRule oRule in instanceRules)
        {
			Destroy(oRule.gameObject);
		}
		instanceRules.Clear();

		if (boss != null)
			Destroy(boss.gameObject);

		Destroy(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Rules.Count;  i++)
        {
			SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
			if (!instanceRules.Contains(rule))
			{
				instanceRules.Add(rule);
			}
        }
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

		if (this.result != LEVEL_RESULT.NONE)
			return;

		if (timeSinceLevelStart > bossTime)
        {
			if (boss == null)
            {
				boss = (Boss)UnitManager.Instance.CreateEnemy(this.Boss.gameObject);
				Player player = Game.Instance.player;
				boss.target = player;
				boss.OnDeath += Boss_OnDeath;
			}
        }
	}

    private void Boss_OnDeath()
    {
		this.result = LEVEL_RESULT.SUCCESS;
		if (this.OnLevelEnd != null)
        {
			this.OnLevelEnd(this.result);
        }
    }
}
