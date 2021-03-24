using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
	public int height;
	public int width;
	public float scale;
    public float heightSacle = 1;

	public bool color;
    public Vector2 offset;

    public bool autoUpdate;
	float[,] noiseMap;
	Texture2D texture;
    // Start is called before the first frame update
    public void generateMap()
    {
     	texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
     	noiseMap = GenerateNoiseMap.generateNoiseMap(height, width, scale, offset);
     	transform.localScale = new Vector3(width, 1, height);
     	for(int y = 0; y < height; y++){
     		for(int x = 0; x < width; x++){
     			if (! color){
     				texture.SetPixel(y,x, Color.Lerp(Color.black, Color.white, noiseMap[y,x]));
     			} else{
     				texture.SetPixel(y,x, getNoiseValueColor(noiseMap[y,x]));
     			}

     		}
     	}

    	drawMesh();

     	texture.Apply();
     	GetComponent<Renderer>().sharedMaterial.SetTexture("_MainTex", texture);

    }


    Color getNoiseValueColor(float value){
    	if(value < .33){
    		return Color.blue;
    	}
    	else if(value < .66){
    		return Color.green;
    	}
    	return Color.grey;
    }


    void drawMesh(){
    	Mesh mesh = TerrainGeneration.generateMesh(noiseMap, heightSacle);
    	GetComponent<MeshFilter>().sharedMesh = mesh;
    	GetComponent<MeshRenderer>().sharedMaterial.mainTexture = texture;
    }
}
