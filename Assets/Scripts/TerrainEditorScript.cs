using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Code used from https://www.youtube.com/watch?v=WP-Bm65Q-1Y&list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3&index=2

[CustomEditor (typeof (MapGenerator))]
public class TerrainEditorScript : Editor
{
    public override void OnInspectorGUI(){
    	MapGenerator mapGen = (MapGenerator) target;
    	

    	if(DrawDefaultInspector()){
    		if(mapGen.autoUpdate){
    			mapGen.generateMap();
    		}
    	}

    	if(GUILayout.Button("Generate Map")){
    		
    	}
    }
}
