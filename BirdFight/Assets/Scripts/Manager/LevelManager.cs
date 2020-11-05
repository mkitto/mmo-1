using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  level的加载、更新和逻辑的执行
 */

public class LevelManager : Singleton<LevelManager> {

	public List<Level> levels;
	public int currentLevelID = 1;

	public Level level;

	public void LoadLevel(int levelID)
	{
		this.level = Instantiate<Level>(levels[levelID - 1]);
		this.level.levelStartTime = Time.realtimeSinceStartup;
	}

	public void UnloadCurLevel()
    {
		if (this.level)
        { 
			this.level.ClearData();

		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
