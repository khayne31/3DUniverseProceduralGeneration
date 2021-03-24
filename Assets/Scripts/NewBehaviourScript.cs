using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{


    // Start is called before the first frame update
    public GameObject myPrefab;
	public Camera myCamera;
    public int sectorWidth;
    public float cameraSpeed;
    Lehmer randGen;

    

    void Start()
    {       
		
		/*for (int i = 0; i < 20; i++)
		{
			Vector3 topRight = myCamera.ViewportToWorldPoint(new Vector3(1, 1, i));
			Vector3 topLeft = myCamera.ViewportToWorldPoint(new Vector3(0, 1, i));
			Vector3 bottomRight = myCamera.ViewportToWorldPoint(new Vector3(1, 0, i));
			Vector3 bottomLeft = myCamera.ViewportToWorldPoint(new Vector3(0, 0, i));
			print(i);
			print("____________________________________________");
			print(topRight);
			print(topLeft);
			print(bottomRight);
			print(bottomLeft);
			GameObject circle = Instantiate(myPrefab, bottomLeft, Quaternion.identity);
		}*/

    
	}

    // Update is called once per frame
    void Update()
    {

        for (short z = 0; z < 30; z++)
        {

            Vector3 topRight = myCamera.ViewportToWorldPoint(new Vector3(1, 1, z));
            Vector3 topLeft = myCamera.ViewportToWorldPoint(new Vector3(0, 1, z));
            Vector3 bottomRight = myCamera.ViewportToWorldPoint(new Vector3(1, 0, z));
            Vector3 bottomLeft = myCamera.ViewportToWorldPoint(new Vector3(0, 0, z));

            // short startX = (short)topLeft.x;
            // short startY = (short)bottomLeft.y;
            // short endX = (short)topRight.x; 
            // short endY = (short)topLeft.y;

            // short cameraWidth = MathF.abs(endX - startX);
            // short cameraHeight = MathF.abs(endY - startY);




            /*print(topRight);
            print(topLeft);
            print(bottomRight);
            print(bottomLeft);*/
            for (short x = (short)topLeft.x; x < topRight.x; x++)
            {
                for (short y = (short)bottomLeft.y; y < topLeft.y; y++)
                {
                    // for (short z = i; z < 21; z++)
                    // {
                        if (x % sectorWidth == 0 && y % sectorWidth == 0 ) {
                            ushort posY = (ushort)y;
							ushort posZ = (ushort)topRight.z;
                            long seed = (long)x << 32 | (long)posY << 16 | (long)posZ;
                            randGen = new Lehmer(seed);

                            long rand = randGen.randomInt(1, 1000);
                            
                            bool starExists = rand == 1;

                            if (starExists && !Physics.CheckSphere(new Vector3(x,y,(short)topRight.z), sectorWidth/2f))
                            {
                                GameObject planet = Instantiate(myPrefab, new Vector3(x, y, (short)topRight.z), Quaternion.identity);
                                float scale = randGen.randomInt(1, 100)/100f;
                                planet.transform.localScale = new Vector3(scale * sectorWidth, scale * sectorWidth, scale*sectorWidth);
                                // print(planet.transform.localScale);

                            }
                        }
                    // }
                }
            }
        }
	}
}
