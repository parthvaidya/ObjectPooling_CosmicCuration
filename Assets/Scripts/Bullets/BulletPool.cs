using CosmicCuration.Utilities;
using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        protected override BulletController CreateItem() => new BulletController(bulletPrefab, bulletSO);

        public BulletController GetBullet() => GetItem();
       
     

      
    }
}