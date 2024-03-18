using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    public int subdivisions = 1;
    public int resolutionAmpification = 8;
    public float radius = 1f;
    public Vector3Int cubeOfSpheres = new Vector3Int(5, 5, 5);
    public float range = 1.5f;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        
        if (meshFilter == null)
            meshFilter = gameObject.AddComponent<MeshFilter>();
        
        if (meshRenderer == null)
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        
        Mesh mesh = GenerateSphereMesh();
        meshFilter.mesh = mesh;
    }
    
    private Mesh GenerateSphereMesh()
    {
        Mesh mesh = new Mesh();
        
        int resolution = subdivisions * resolutionAmpification;
        // Vector3[] vertices = new Vector3[(resolution + 1) * (resolution + 1)];
        List<Vector3> vertices = new List<Vector3>();
        //int[] triangles = new int[(resolution + 1) * (resolution + 1) * 6];
        List<int> triangles = new List<int>();
        
        int vertexIndex = 0;

        for (var a = 0; a < cubeOfSpheres.x; a++)
        {
            for (var b = 0; b < cubeOfSpheres.y; b++)
            {
                for (var c = 0; c < cubeOfSpheres.z; c++)
                {
                    
                    for (int i = 0; i <= resolution; i++)
                    {
                        float lat = Mathf.PI * (-0.5f + (float)i / resolution);
                        float y = b * range + Mathf.Sin(lat);
                        float radiusAtLat = Mathf.Cos(lat);

                        for (int j = 0; j <= resolution; j++)
                        {
                            float lon = 2f * Mathf.PI * (float)j / resolution;
                            float x = a * range + Mathf.Cos(lon) * radiusAtLat;
                            float z = c * range + Mathf.Sin(lon) * radiusAtLat;

                            // vertices[vertexIndex] = new Vector3(x, y, z) * radius;
                            vertices.Add(new Vector3(a * range + x, b * range + y, c * range + z) * radius);

                            if (i < resolution && j < resolution)
                            {
                                int baseIndex = i * (resolution + 1) + j;
                                // triangles[vertexIndex * 6] = baseIndex;
                                // triangles[vertexIndex * 6 + 1] = baseIndex + resolution + 1;
                                // triangles[vertexIndex * 6 + 2] = baseIndex + resolution + 2;
                                // triangles[vertexIndex * 6 + 3] = baseIndex;
                                // triangles[vertexIndex * 6 + 4] = baseIndex + resolution + 2;
                                // triangles[vertexIndex * 6 + 5] = baseIndex + 1;
                                triangles.Add(baseIndex);
                                triangles.Add(baseIndex + resolution + 1);
                                triangles.Add(baseIndex + resolution + 2);
                                triangles.Add(baseIndex);
                                triangles.Add(baseIndex + resolution + 2);
                                triangles.Add(baseIndex + 1);
                            }

                            // vertexIndex++;
                        }
                    }
                    
                }
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        return mesh;
    }
}