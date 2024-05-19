using UnityEngine;

namespace Assets.CyberCity.Script
{
    public class CCTvMovie : MonoBehaviour
    {
        [ColorUsage(true, true)]
        public Color MaxBright = Color.black;
        public float Speed;
        public int MatId;
        public Texture[] Frames;
        private int i;
        private Material _Material;

        private void Awake()
        {
            Random.InitState((int)System.DateTime.Now.Ticks * 1000);
        }

        // Use this for initialization
        private void Start()
        {
            _Material = GetComponent<Renderer>().materials[MatId];
            //bright
            float random = Random.Range(1.0f, 1.5f);
            //color variations
            float random2 = Random.Range(0.2f, 0.8f);
            float random3 = Random.Range(0.2f, 0.8f);
            float random4 = Random.Range(0.2f, 0.8f);
            _Material.SetColor("_EmissiveColor", new Color(random + random2, random + random3, random + random4));
            //emission level
            if (MaxBright != Color.black)
            {
                GetComponent<Renderer>().materials[MatId].SetColor("_EmissiveColor", MaxBright);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            i = (int)(Time.time * Speed);
            i %= Frames.Length;
            _Material.SetTexture("_EmissiveColorMap", Frames[i]);
        }
    }
}