using System;
using Network;
using UnityEngine;

using Common.Data;
using SkillBridge.Message;
using Models;
using Services;
using Managers;
using Entities;

public class MapService : Singleton<MapService>, IDisposable
{

	public int CurrentMapId = 0;

	public MapService()
    {
        MessageDistributer.Instance.Subscribe<MapCharacterEnterResponse>(this.OnMapCharacterEnter);
        MessageDistributer.Instance.Subscribe<MapCharacterLeaveResponse>(this.OnMapCharacterLeave);
        MessageDistributer.Instance.Subscribe<MapEntitySyncResponse>(this.OnMapEntitySync);
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
        foreach (var cha in response.Characters)
        {
            if(User.Instance.CurrentCharacter == null || User.Instance.CurrentCharacter.Id == cha.Id)
            {
                // 更新当前角色数据
                User.Instance.CurrentCharacter = cha;
            }
            CharacterManager.Instance.AddCharacter(cha);
        }
        if(CurrentMapId != response.mapId)
        {
            // 进入地图
            this.EnterMap(response.mapId);
            this.CurrentMapId = response.mapId;
        }
    }

    private void OnMapCharacterLeave(object sender,  MapCharacterLeaveResponse response)
    {
        Debug.LogFormat("[TEST]OnMapCharacterLeave: CharID: {0}", response.characterId);
        int characterID = response.characterId;
        if (characterID != User.Instance.CurrentCharacter.Id)
        {
            // 其他玩家角色
            CharacterManager.Instance.RemoveCharacter(characterID);
        }
        else
        {
            CharacterManager.Instance.Clear();
        }
    }

    private void OnMapEntitySync(object sender, MapEntitySyncResponse response)
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

    public void SendMapEntitySync(EntityEvent entityEvent, NEntity entity)
    {
        Debug.LogFormat("MapEntityUpdateRequest:  ID: {0}  POS: {1}  DIR: {2}  SPD: {3}", entity.Id, entity.Position.String(), entity.Direction.String(), entity.Speed);
        NetMessage message = new NetMessage();
        message.Request = new NetMessageRequest();
        message.Request.mapEntitySync = new MapEntitySyncRequest();
        message.Request.mapEntitySync.entitySync = new NEntitySync()
        {
            Id = entity.Id,
            Event = entityEvent,
            Entity = entity,
        };
        NetClient.Instance.SendMessage(message);
    }
}
