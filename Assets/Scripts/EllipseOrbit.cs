using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseOrbit
{

	float a;
	float b;
	Vector3 center;
	float theta = 45;
	int time = 0;
    // Start is called before the first frame update
    public EllipseOrbit(float a_in, float b_in, Vector3 center)
    {
        this.a = a_in;
        this.b = b_in;
        this.center = center;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   	public float getA(){
   		return a;
   	}

   	public float getB(){
   		return b;
   	}

    public void setTheta(float theta){
    	this.theta = theta;
    }

    public float getTheta(){
    	return theta;
    }

    public int getTime(){
    	return time;
    }

    public void incrementTime(){
    	time++;
    }

    public Vector3 getCenter(){
    	return center;
    }

    public void setCenter(Vector3 center){
    	this.center = center;
    }


    public float partialXEllipseDeriv(float x, float b, float h){
        return 2*(x - h) / (b * b);
    }

    public float partialYEllipseDeriv(float y, float a, float k){
        return 2*(y - k) / (a * a);
    }


}
