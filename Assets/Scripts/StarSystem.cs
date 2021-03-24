using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameInfoObject;
    public GameObject starPrefab;
    public GameObject planetPrefab;
    public GameObject moonPrefab;
  	public int maxNumPlanets = 10;
    public float maxPlanetScale = .1f;
    public int maxPlanetRadiusDistance= 5;
    public int maxMoonRadiusDistance = 2;
    public int maxNumMoons = 5;
    public int minPlanetMass = 10000;
    public int maxPlanetMass = 1000000;
    public int maxVectorMagFromPlanet = 5;
    public float moonMassSacle = .9f;
    public int resolution = 1000;
    [Range(0f, .5f)]
    public float compensationFactor = 0;
    

    int minMoonMass;
    int maxMoonMass;
    Rigidbody[] rigidBodies;
    int x;
    int y;
    int z;
    long nLehmer = 0;
    int planetRadius = 1;
    float scale;
    int numPlanets;
    int numMoons;
    Vector3 starPoisiton = new Vector3(0, 0, 0);
    GameObject[] planetsGameObjects;
    Planet[] planets;
    GameObject[,] moonsGameObjects;
    Moon[,] moons;
    EllipseOrbit[,] orbits;
    Lehmer randGenerator;


    Star currentStar = new Star();
    Vector3 startVelocity = new Vector3(0f, 5f, 0f);
  
    void Start()
    {	
          minMoonMass = (int) (minPlanetMass * moonMassSacle);
          maxMoonMass = (int) (maxPlanetMass * moonMassSacle);
          
          x = gameInfoObject.GetComponent<GameInfo>().x;
          y = gameInfoObject.GetComponent<GameInfo>().y;
          z = gameInfoObject.GetComponent<GameInfo>().z;
          GameObject star = Instantiate(starPrefab, starPoisiton, Quaternion.identity);

     	  ushort posY = (ushort)y;
		  ushort posZ = (ushort)z;
     	  nLehmer = (long)x << 32 | (long)posY << 16 | (long)posZ;
          randGenerator = new Lehmer(nLehmer);

     	  bool starExists = randGenerator.randomInt(0,15) == 1;
     	  scale = randGenerator.randomInt(1, 100)/100f;
     	  numPlanets = (int)randGenerator.randomInt(0, maxNumPlanets);
          // numPlanets = 1;

          planetsGameObjects = new GameObject[numPlanets];
          rigidBodies = new Rigidbody[numPlanets];
          planets = new Planet[numPlanets];
          moons = new Moon[numPlanets, maxNumMoons];
          moonsGameObjects = new GameObject[numPlanets, maxNumMoons];
          orbits = new EllipseOrbit[numPlanets, maxNumMoons];




          for(int i = 0; i < numPlanets; i++){
            int maxPlanetScaleToInt = (int)(maxPlanetScale * 100);
            float planetScale = (maxPlanetScaleToInt - 1 - (uint)randGenerator.randomInt(1, maxPlanetScaleToInt - 1)) / 100f;
            Vector3 planetPosition = new Vector3(randGenerator.randomInt(-maxPlanetRadiusDistance, maxPlanetRadiusDistance),
                                                 randGenerator.randomInt(-maxPlanetRadiusDistance, maxPlanetRadiusDistance),
                                                 randGenerator.randomInt(-maxPlanetRadiusDistance, maxPlanetRadiusDistance));

            GameObject planet = Instantiate(planetPrefab, planetPosition, Quaternion.identity);
            planetsGameObjects[i] = planet;
            planets[i] = new Planet();
            // startVelocity = (starPoisiton - planetPosition).normalized;
            // planets[i].setVelocity(startVelocity);
            planets[i].setMass((float)randGenerator.randomInt(minPlanetMass, maxPlanetMass));

            //MOOOOOOOOOOOOOOOOOOOOON
            numMoons =(int)randGenerator.randomInt(0, maxNumMoons);
            planets[i].setNumMoons(numMoons);



            for(int j =0; j < numMoons; j++){
                Vector3 moondistance = new Vector3(randGenerator.randomInt(-maxMoonRadiusDistance, maxMoonRadiusDistance),
                                                 randGenerator.randomInt(-maxMoonRadiusDistance, maxMoonRadiusDistance),
                                                 randGenerator.randomInt(-maxMoonRadiusDistance, maxMoonRadiusDistance));

                Vector3 moonPosition = moondistance + planetPosition;

                float minMagnitude = moonPosition.magnitude + planetRadius + 1;
                float maxMagnitude = minMagnitude + maxVectorMagFromPlanet;
                float mag = (float)randGenerator.randomInt((int)minMagnitude, (int)maxMagnitude);
                float b = mag / 2;

                Vector3 ellipseEndpoint = (mag * -1 * moondistance) + moonPosition; 
                Vector3 midPoint = (b * -1 * moonPosition) + moonPosition;

                 Vector3 normal = moondistance;
                 Vector3 tangent;
                 Vector3 t1 = Vector3.Cross( normal, Vector3.forward );
                 Vector3 t2 = Vector3.Cross( normal, Vector3.up );
                 if( t1.magnitude > t2.magnitude )
                 {
                     tangent = t1;
                 }
                 else
                 {
                     tangent = t2;
                }

                float a = (float)randGenerator.randomInt((int)minMagnitude, (int)maxMagnitude);
                orbits[i,j] = new EllipseOrbit(a * .2f, b * .2f, midPoint);
                orbits[i, j].setTheta((float)randGenerator.randomInt(0,90));



                GameObject moon = Instantiate(moonPrefab, moonPosition, Quaternion.identity);
                moonsGameObjects[i,j] = moon;
                moons[i,j] = new Moon();
                //moons[i, j].setVelocity(startVelocity);
                moons[i, j].setMass((float)randGenerator.randomInt(minMoonMass, maxMoonMass));

            }

         

          }


    }

    // Update is called once per frame
    void FixedUpdate ()
    {   
        for(int i = 0; i < numPlanets; i++){

            // float time = .005f;
            // float celestialMass = planets[i].getMass();
            // Vector3 velocity = planets[i].getVelocity();
            // GameObject celestialGameObject = planetsGameObjects[i];
            // Vector3 originalPos = celestialGameObject.transform.position;
            // Vector3 acceleration = (calcForce(originalPos, celestialMass, starPoisiton, currentStar.getMass())/celestialMass);
            // celestialGameObject.transform.position += (velocity * time + .5f * acceleration * time * time);
            // Vector3 newPosition = celestialGameObject.transform.position;
            // velocity = (newPosition - originalPos) / time;
            // planets[i].setVelocity(velocity);
                
            Vector3 newVelocity = updateVelocity(planets[i], planetsGameObjects[i], currentStar, starPoisiton, false); 
            planets[i].setVelocity(newVelocity);

            for(int j = 0; j < planets[i].getNumMoons(); j++){
                EllipseOrbit ellipse = orbits[i,j];
                ellipse.setCenter(planetsGameObjects[i].transform.position);
                Quaternion q = Quaternion.AngleAxis(ellipse.getTheta(), Vector3.forward);
                float angle = (float)ellipse.getTime() / (float)resolution * 2.0f * Mathf.PI;
                Vector3 newPos = new Vector3(ellipse.getA() * Mathf.Cos (angle), ellipse.getB() * Mathf.Sin (angle), ellipse.getCenter().z);
                moonsGameObjects[i,j].transform.position = q * newPos + ellipse.getCenter();
                ellipse.incrementTime();
            }

        }
        
    }


    public Vector3 calcForce(Vector3 currentPosition, float currentMass, Vector3 targetPosition, float targetMass, bool isMoon){
        float distance = Vector3.Distance(targetPosition, currentPosition);

        float GravitationalConstant = 6.67f * Mathf.Pow(10, -11);
        float force = GravitationalConstant * currentMass * targetMass / (distance * distance);
        Vector3 heading = (targetPosition - currentPosition);
        Vector3 forceDirection = (force * (heading.normalized));
        return (forceDirection);
    }   


    Vector3 updateVelocity(CelestialObject celestialObject, GameObject gameObject, 
        CelestialObject targetCelestial, Vector3 targetPosition, bool isMoon){
        float time =  isMoon ? 1 :.005f;
        float celestialMass = celestialObject.getMass();
        Vector3 velocity = celestialObject.getVelocity();
        GameObject celestialGameObject = gameObject;
        Vector3 originalPos = celestialGameObject.transform.position;
        Vector3 acceleration = (calcForce(originalPos, celestialMass, targetPosition, targetCelestial.getMass(), isMoon)/celestialMass);
        print(acceleration);
        celestialGameObject.transform.position += (velocity * time + .5f * acceleration * time * time);
        Vector3 newPosition = celestialGameObject.transform.position;
        velocity = (newPosition - originalPos) / time;
        return velocity;
    }



    





}
