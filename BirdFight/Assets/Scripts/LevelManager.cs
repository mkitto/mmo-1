using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  level的加载、更新和逻辑的执行
 */

public class LevelManager : MonoBehaviour {

	public List<Level> levels;
	public int currentLevelID = 1;

	//public Level level
	//{
	//	get
	//	{
	//		return this.levels[this.currentLevelID - 1];
	//	}
	//}

	public Level level;

	public void LoadLevel(int levelID)
	{
		this.level = Instantiate<Level>(levels[levelID - 1]);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
