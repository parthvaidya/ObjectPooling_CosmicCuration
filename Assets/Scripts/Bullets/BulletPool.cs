using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletSO;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();
        public BulletPool(BulletView bulletView , BulletScriptableObject bulletSO)
        {
            this.bulletView = bulletView;
            this.bulletSO = bulletSO;
        }

        public BulletController GetBullet()
        {
            if(pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => item.isUsed);
                if(pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.Bullet;
                }
            }

           return CreateNewPooledBullets();
        }

        public void ReturnBulletPool(BulletController returnedBullet)
        {
            PooledBullet pooledBullet = pooledBullets.Find(item => item.Bullet.Equals(returnedBullet));
            pooledBullet.isUsed = false;
        }
        private BulletController CreateNewPooledBullets()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Bullet = new BulletController(bulletView, bulletSO);
            pooledBullet.isUsed = true;
            pooledBullets.Add(pooledBullet);
            return pooledBullet.Bullet;
        }

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}
