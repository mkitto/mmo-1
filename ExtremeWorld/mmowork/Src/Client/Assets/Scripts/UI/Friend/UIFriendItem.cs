using SkillBridge.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendItem : ListView.ListViewItem 
{
    public Text nickname;
    public Text friendClass;
    public Text level;
    public Text status;

    public Image background;
    public Sprite normalBg;
    public Sprite selectBg;

    public override void onSelected(bool selected)
    {
        this.background.overrideSprite = selected ? selectBg : normalBg;
    }

    public NFriendInfo Info;
    bool isEquiped = false;

    public void SetFriendInfo(NFriendInfo item)
    {
        this.Info = item;
        if (this.nickname != null) this.nickname.text = this.Info.friendInfo.Name;
        if (this.friendClass != null) this.friendClass.text = this.Info.friendInfo.Class.ToString();
        if (this.level != null) this.level.text = this.Info.friendInfo.Level.ToString();
        if (this.status != null) this.status.text = this.Info.Status == 1 ? "在线" : "离线";
    }

}
