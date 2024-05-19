using Config;
using UnityEngine;

namespace _Common
{
    [AddComponentMenu("Scripts/_Common/_Common.ResetLock")]
    internal class ResetLock : MonoBehaviour
    {

        private void Awake()
        {
            Locker.instance.InFPSLock();
        }
    }
}
