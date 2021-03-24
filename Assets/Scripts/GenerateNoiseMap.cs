using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNoiseMap
{
	public static float[,] generateNoiseMap(int height, int width, float scale, Vector2 offset){

		float[,] noiseMap = new float[height, width];
		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				noiseMap[y,x] = Mathf.PerlinNoise((x + offset.x)/scale, (y + offset.y)/scale);
			}
		}

		return noiseMap;
	}
}
