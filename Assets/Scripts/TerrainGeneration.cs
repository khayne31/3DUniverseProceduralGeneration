using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainGeneration
{

    public static Mesh generateMesh(float[,] heightMap, float heightScale){
    	int height = heightMap.GetLength(0);
    	int width = heightMap.GetLength(1);
    	Mesh mesh = new Mesh();
		Vector3[] vertexList = new Vector3[height * width];
		int[] triangleList = new int[6 * (height - 1) * (width - 1)];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{

				vertexList[y * height + x]= new Vector3(x - width/2, heightMap[y,x] * heightScale, y - height/2);
			}
		}
		for (int y = 0; y < height - 1; y++)
		{
			for (int x = 0; x < width - 1; x++)
			{
				int startingVertex = (y * height) + x;
				int index = ((y * (height - 1)) + x) * 6;
				triangleList[index + 0] = startingVertex + 0;
				triangleList[index + 1] = startingVertex + width;
				triangleList[index + 2] = startingVertex + 1;
				triangleList[index + 3] = startingVertex + 1;
				triangleList[index + 4] = startingVertex + width;
				triangleList[index + 5] = startingVertex + width + 1;
			}

		}
		Vector2[] uvs = new Vector2[vertexList.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2((float)vertexList[i].x / width, (float)vertexList[i].z/height);
        }
        mesh.vertices = vertexList;
        mesh.uv = uvs;
		mesh.triangles = triangleList;
		mesh.RecalculateNormals();

		return mesh;
    }
}
