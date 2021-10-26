﻿using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIQuestItem : ListView.ListViewItem
{
	public Text title;
	public Image backgroud;
	public Sprite normalBg;
	public Sprite selectedBg;

	public override void onSelected(bool selected)
    {
		this.backgroud.overrideSprite = selected ? selectedBg : normalBg;
    }

	public Quest quest;

	bool isEquiped = false;

	public void SetQuestInfo(Quest item)
    {
		this.quest = item;
		if (this.title != null) this.title.text = this.quest.Define.Name;
    }
}
