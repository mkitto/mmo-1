﻿using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain: MonoSingleton<UIMain> {

	public Text avatarName;
	public Text avatarLevel;

	// Use this for initialization
	protected override void OnStart () {
		this.UpdateAvatar();
	}

	void UpdateAvatar()
	{
		this.avatarName.text = string.Format("{0}[{1}]", User.Instance.CurrentCharacter.Name, User.Instance.CurrentCharacter.Id);
		this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
	}


	public void BackToCharSelect() {
		SceneManager.Instance.LoadScene("CharSelect");
		Services.UserService.Instance.SendGameLeave();
	}

	public void OnClickBag()
    {
		UIManager.Instance.Show<UIBag>();
    }

    public void OnClickEquip()
    {
        UIManager.Instance.Show<UICharEquip>();
    }
}
