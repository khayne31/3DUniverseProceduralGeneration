using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    float theta = Mathf.PI;
    float radius = 1; 	
    List<Vector3> verticies = new List<Vector3>();
    int n = 10;
    int z = 0; 
    float width = 1;
    float length = 1;
    float height = 1;
    int res = 100;
    public Material material;
    Mesh mesh = new Mesh();

    List<int> triangles = new List<int>();
    void Start()
    {
    	float phi = (2f * Mathf.PI) / n;
		float theta = Mathf.PI / n;

		verticies.Add(new Vector3(0, radius, 0));
    	for(int i=1; i < n-1; i++){
    		float stackRadiusX = Mathf.Sin(theta * i) * width;
    		float stackRadiusZ = Mathf.Sin(theta * i) * length;
    		for(int j=0; j < n-1; j++){
    			float x = Mathf.Cos(phi * j) * stackRadiusX;
    			float y = Mathf.Cos(theta * i) * height;
    			float z = Mathf.Sin(phi * j) * stackRadiusZ;

    			verticies.Add(new Vector3(x,y,z));
    		}
    	}
    	verticies.Add(new Vector3(0, radius, 0));


    	for(int i=0; i < n - 2; i++){
    		triangles.Add(i);
    		triangles.Add(i + 1);
    		triangles.Add(i + 2);
    	}
    	triangles.Add(0);
    	triangles.Add(1);
    	triangles.Add(res);

    	int i1;
    	int i2;
    	int i3;
    	int i4;

    	for(int i = 0; i < res -3; i++){
    		for(int j = 0; j < res - 2; j++){
    			i1 = 1 + j + (res * i);
    			i2 = i1 + 1;
    			i3 = 1 + j + (res * (i + 1));
    			i4 = i3 + 1;
    			triangles.Add(i1);
    			triangles.Add(i2);
    			triangles.Add(i4);
    			triangles.Add(i1);
    			triangles.Add(i4);
    			triangles.Add(i3);
    		}
    		i1 = res * (res * i);
			i2 = 1 + (res * i);
			i3 = res * (i + 2);
			i4 = 1  + (res * (i + 1));
			triangles.Add(i1);
			triangles.Add(i2);
			triangles.Add(i4);
			triangles.Add(i1);
			triangles.Add(i4);
			triangles.Add(i3);
    	}

    	for(int i = 0; i < res - 2; i++){
    		i2 = (res-2)*res + i + 1;
    		i3 = i2 + 1;
    		triangles.Add(verticies.Count - 1);
    		triangles.Add(i2);
    		triangles.Add(i3);
    	}
    	triangles.Add(verticies.Count - 1);
    	triangles.Add((res-1)*res);
    	triangles.Add((res-2)*res + 1);	

        
        //GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices  = verticies.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        // meshRenderer.material = material;
		
        // var filter = gameObject.AddComponent<MeshFilter>();
        // filter.mesh = mesh;

        // GetComponent(MeshRenderer).enabled = true;



    }

    // Update is called once per frame
    void Update()
    {
    }
}
