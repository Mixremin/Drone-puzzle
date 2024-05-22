using UnityEngine;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.LineRendereCollider")]
    [RequireComponent(typeof(LineRenderer))]
    internal class LineRendereCollider : MonoBehaviour
    {
        public LineRenderer Line;
        public Vector3[] InitialState = new Vector3[1];
        public float SmoothingLength = 2f;
        public int SmoothingSections = 10;

        //private void OnGUI()
        //{
        //    if (GUI.Button(new Rect(10, 60, 300, 40), "Generate Collider"))
        //    {
        //        GenerateMeshCollider();
        //    }
        //    if (GUI.Button(new Rect(10, 110, 300, 40), "Simplify Mesh"))
        //    {
        //        Line.Simplify(0.1f);
        //    }
        //}

        private void Start()
        {
            GenerateMeshCollider();
        }

        public void GenerateMeshCollider()
        {
            MeshCollider collider = GetComponent<MeshCollider>();

            if (collider == null)
            {
                collider = gameObject.AddComponent<MeshCollider>();
            }


            Mesh mesh = new();
            Line.BakeMesh(mesh, true);

            // if you need collisions on both sides of the line, simply duplicate & flip facing the other direction!
            // This can be optimized to improve performance ;)
            int[] meshIndices = mesh.GetIndices(0);
            int[] newIndices = new int[meshIndices.Length * 2];

            int j = meshIndices.Length - 1;
            for (int i = 0; i < meshIndices.Length; i++)
            {
                newIndices[i] = meshIndices[i];
                newIndices[meshIndices.Length + i] = meshIndices[j];
            }
            mesh.SetIndices(newIndices, MeshTopology.Triangles, 0);

            collider.sharedMesh = mesh;
        }

    }
}
