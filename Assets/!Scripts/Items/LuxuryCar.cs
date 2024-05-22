using _Config;
using _Cutscene;
using _LevelSpecific;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.LuxuryCar")]
    internal class LuxuryCar : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private int tickCount = 10;

        [SerializeField]
        private Starter carCutscene;
        public void TakeTick()
        {
            if (SimpleInventory.instance.hackerQuestPassed)
            {
                tickCount--;

                if (tickCount <= 0)
                {
                    carCutscene.StartCutscene();
                    Destroy(this);
                }
            }
        }
    }
}
