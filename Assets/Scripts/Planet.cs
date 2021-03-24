using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet: CelestialObject
{

    int numMoons = 0;
    
    // Start is called before the first frame update
    public Planet(){
      velocity = new Vector3(0,6f,0);
      mass = 10000f;  
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumMoons(){
        return numMoons;
    }

    public void setNumMoons(int n){
        numMoons = n;
    }

 

}
