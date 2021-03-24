using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon: CelestialObject
{
	

    public Moon(){
    	velocity = new Vector3(0,.00001f,0);
    	mass = 100f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
