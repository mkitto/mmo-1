using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuestDialog : UIWindow {
	public Quest quest;
	public GameObject openButtons;
	public GameObject submitButtons;
	public UIQuestInfo questInfo;

	public void SetQuest(Quest quest)
    {
		this.quest = quest;
		this.UpdateQuest();
		if (this.quest.Info == null)
        {
			openButtons.SetActive(true);
			submitButtons.SetActive(false);
        }
		else
        {
			if (this.quest.Info.Status == SkillBridge.Message.QuestStatus.Complete)
            {
                openButtons.SetActive(false);
                submitButtons.SetActive(true);
            }
			else
            {
                openButtons.SetActive(false);
                submitButtons.SetActive(false);
            }
        }
    }

	void UpdateQuest()
	{
		if (this.quest != null)
        {
			if (this.questInfo != null)
            {
				this.questInfo.SetQuestInfo(quest);
            }
        }
}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
