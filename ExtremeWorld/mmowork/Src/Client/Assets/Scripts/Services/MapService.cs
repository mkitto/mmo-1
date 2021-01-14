using System;
using Network;
using UnityEngine;

using Common.Data;
using SkillBridge.Message;
using Models;


public class MapService : Singleton<MapService>, IDisposable
{

	public int CurrentMapId = 0;

	public MapService()
    {
        MessageDistributer.Instance.Subscribe<MapCharacterEnterResponse>(this.OnMapCharacterEnter);
        MessageDistributer.Instance.Subscribe<MapCharacterLeaveResponse>(this.OnMapCharacterLeave);
    }

    public void Init()
    {

    }

    public void Dispose()
    {
        MessageDistributer.Instance.Unsubscribe<MapCharacterEnterResponse>(this.OnMapCharacterEnter);
        MessageDistributer.Instance.Unsubscribe<MapCharacterLeaveResponse>(this.OnMapCharacterLeave);
    }

    private void OnMapCharacterEnter(object sender, MapCharacterEnterResponse response)
    {
        // 当前角色切换地图
        foreach (var cha in response.Characters)
        {
            if(User.Instance.CurrentCharacter.Id == cha.Id)
            {
                User.Instance.CurrentCharacter = cha;
            }
            CharacterManager.Instance.AddCharacter(cha);
        }
        if(CurrentMapId != response.mapId)
        {
            
        }
    }

    private void OnMapCharacterLeave(object sender,  MapCharacterLeaveResponse response)
    {

    }

    private void EnterMap(int mapId)
    {
        if (DataManager.Instance.Maps.ContainsKey(mapId))
        {
            MapDefine map = DataManager.Instance.Maps[mapId];
            SceneManager.Instance.LoadScene(map.Resource);
        }
        else
        {
            Debug.LogErrorFormat("EnterMap：Map {0} not existed", mapId);
        }    
    }
}
