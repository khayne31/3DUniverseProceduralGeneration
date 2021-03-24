using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject
{
	protected Vector3 velocity;
    protected float mass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVelocity(Vector3 v){
    	velocity = v;
    }

    public Vector3 getVelocity(){
    	return velocity;
    }

    public void setMass(float m){
        mass = m;
    }

    public float getMass(){
        return mass;
    }
}
