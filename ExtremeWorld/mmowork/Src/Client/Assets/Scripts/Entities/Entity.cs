using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SkillBridge.Message;

namespace Entities
{
    /*
     * 纯逻辑对象，提供接口对位置、方向、速度等进行更新
    */
    public class Entity
    {
        public int entityId;
        public Vector3Int position;
        public Vector3Int direction;
        public int speed;

        private NEntity entityData;  // 从服务器同步到客户端的信息

        public NEntity EntityData
        {
            get
            {
                UpdateEntityData();
                return entityData;
            }
            set
            {
                entityData = value;
                this.SetEntityData(value);
            }
        }

        public Entity(NEntity entity)
        {
            this.entityId = entity.Id;
            this.entityData = entity;
            this.SetEntityData(entity);
        }

        public void SetEntityData(NEntity entity)
        {
            this.position = this.position.FromNVector3(entity.Position);
            this.direction = this.direction.FromNVector3(entity.Direction);
            this.speed = entity.Speed;
        }

        public virtual void OnUpdate(float delta)
        {
            if (this.speed != 0)
            {
                // Q: 为什么要转换之后参与运算？
                // A：没有参数为float类型的运算符重载函数
                Vector3 dir = this.direction;
                // Q：为啥要 / 100f
                this.position = Vector3Int.RoundToInt(dir * speed * delta / 100f);
            }
        }

        private void UpdateEntityData()
        {
            entityData.Position.FromVector3Int(this.position);
            entityData.Direction.FromVector3Int(this.direction);
            entityData.Speed = this.speed;
        }
    }
}