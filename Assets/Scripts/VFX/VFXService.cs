using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private List<VFXData> vfxData = new List<VFXData>();
        private VFXPool vfxPool;

        public VFXService(VFXScriptableObject vfxScriptableObject) => vfxData = vfxScriptableObject.vfxData;

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            VFXController vfxToPlay = new VFXController(prefabToSpawn);
            vfxToPlay.Configure(spawnPosition);
        }

        public void ReturnVFXToPool(VFXController vfxToReturn) => vfxPool.ReturnItem(vfxToReturn);
    } 
}