using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SkillBridge.Message;

namespace Entities
{
    /*
     *  纯逻辑对象，标识角色，提供接口对角色位置、方向、速度等进行更新
     */
    public class Character : Entity
    {
        public NCharacterInfo Info;  // 从服务器同步到客户端的信息
        public Common.Data.CharacterDefine Define;  // 导表数据

        public string Name
        {
            get
            {
                if (this.Info.Type == CharacterType.Player)
                {
                    return this.Info.Name;
                }
                else
                {
                    return this.Define.Name;
                }
            }
        }

        public bool IsPlayer
        {
            get
            {
                return this.Info.Id == Models.User.Instance.CurrentCharacter.Id;
            }
        }

        public Character(NCharacterInfo info) : base(info.Entity)
        {
            this.Info = info;
            this.Define = DataManager.Instance.Characters[Info.Tid];
        }

        public void MoveForward()
        {
            //Debug.LogFormat("MoveForward");
            this.speed = this.Define.Speed;
        }

        public void MoveBack()
        {
            //Debug.LogFormat("MoveBack");
            this.speed = -this.Define.Speed;
        }

        public void Stop()
        {
            //Debug.LogFormat("Stop");
            this.speed = 0;
        }

        public void SetDirection(Vector3Int direction)
        {
            //Debug.LogFormat("SetDirection:{0}", direction);
            this.direction = direction;
        }

        public void SetPosition(Vector3Int position)
        {
            //Debug.LogFormat("SetPosition:{0}", position);
            this.position = position;
        }
    }
}