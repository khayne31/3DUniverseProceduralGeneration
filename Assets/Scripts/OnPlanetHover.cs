using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlanetHover : MonoBehaviour
{
	TrailRenderer trail;
	AnimationCurve curve;
	bool showOrbit;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        curve = new AnimationCurve();
        trail.material = new Material(Shader.Find("Sprites/Default"));
        //trail.material.SetColor("_TintColor", new Color(255f, 255f, 2f));
        
        curve.AddKey(0.0f, 0.0f);
        curve.AddKey(0f, 0f);
       

        trail.widthCurve = curve;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
	{    
		if(!showOrbit){
			curve.AddKey(0.0f, 0.0f);
        	curve.AddKey(.1f, .1f);
        	trail.widthMultiplier = 1f;
        	showOrbit = !showOrbit;
		}
		else{
			curve.AddKey(0.0f, 0.0f);
        	curve.AddKey(0f, 0f);
        	trail.widthMultiplier = 0f;
        	showOrbit = !showOrbit;
		}
        trail.widthCurve = curve;
	}

}
