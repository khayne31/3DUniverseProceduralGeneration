using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lehmer 
{
    // Start is called before the first frame update
	long nLehmer = 0;


    public Lehmer(long seed){
        nLehmer = seed;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    long lehmer() {
        nLehmer += 0xe120fc15;
        long  temp = nLehmer * 0x4a39b70d;
        long  m1 = temp >> 32 ^ temp;
        temp = m1 * 0x12fad5c9;
        long  m2 = temp >> 32 ^ temp;
    return m2;  
    }

    public long randomInt(int min, int max){
        return lehmer() % ((max + 1) - min) + min;
    }
}
