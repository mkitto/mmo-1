using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : Singleton<Game>
{

	public enum GAME_STATUS
	{
		Ready,
		InGame,
		GameOver
	}

	private GAME_STATUS _status;

	public GAME_STATUS Status
	{
		get
        {
			return _status;
        }
		set
        {
			_status = value;
			UIManager.Instance.UpdateUI();
		}
	}

	public Player player;
	public int score;
	public int currentLevelID = 1;

	public int Score
    {
		get
        {
			return score;
        }
        set
        {
			this.score = value;
        }
    }

	new void Awake()
    {
		base.Awake();
		var obj =  Resources.Load("Level1");
		var gameObj =  GameObject.Instantiate(obj);
		gameObj.name = "test";
	}

	// Use this for initialization
	void Start()
	{
		player.Idle();
		UIManager.Instance.UpdateLifeText(player.life);
		player.OnDeath += Player_OnDeath;
	}

	private void Player_OnDeath()
    {
		if (this.player.life <= 0)
        {
			this.Status = GAME_STATUS.GameOver;

		}
		else
        {
			UIManager.Instance.UpdateLifeText(player.life);
		}
	}


	// Update is called once per frame
	void Update()
	{

	}

	void OnDestroy()
    {
		Debug.Log("------OnDestroy");
	}

	public void StartGame()
    {
		this.Status = GAME_STATUS.InGame;
		Debug.LogFormat("StartGame: {0}", this._status);
		player.Fly();
		this.Score = 0;
		LevelManager.Instance.LoadLevel(this.currentLevelID);
		UIManager.Instance.UpdateLevelName(string.Format("LEVEL {0}  {1}", LevelManager.Instance.level.LevelID, LevelManager.Instance.level.Name));
		LevelManager.Instance.level.OnLevelEnd = OnLevelEnd;
	}

	void OnLevelEnd(Level.LEVEL_RESULT result)
    {
		int maxLevel = LevelManager.Instance.levels.Count;
		if (result == Level.LEVEL_RESULT.SUCCESS && this.currentLevelID < maxLevel)
		{
			LevelManager.Instance.UnloadCurLevel();
			this.currentLevelID++;
			Debug.Log("this.currentLevelID < LevelManager.Instance.levels.Count");
			LevelManager.Instance.LoadLevel(this.currentLevelID);
			LevelManager.Instance.level.OnLevelEnd = OnLevelEnd;
			UIManager.Instance.UpdateLevelName(string.Format("LEVEL {0}  {1}", LevelManager.Instance.level.LevelID, LevelManager.Instance.level.Name));
		}
		else if (result == Level.LEVEL_RESULT.SUCCESS && this.currentLevelID >= maxLevel)
		{
			Debug.Log("this.currentLevelID >= LevelManager.Instance.levels.Count");
			this.Status = GAME_STATUS.GameOver;
			UIManager.Instance.UpdateLeftLife(this.player.life);
		}
		else
		{
			this.Status = GAME_STATUS.GameOver;
			UIManager.Instance.UpdateLeftLife(this.player.life);
		}
    }

	public void Restart()
    {

		this.Status = GAME_STATUS.Ready;
		player.Init();
	}
}
