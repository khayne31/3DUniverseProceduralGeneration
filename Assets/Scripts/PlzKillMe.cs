using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlzKillMe : MonoBehaviour
{
	// Start is called before the first frame update
	public Behaviour halo;
	public GameObject player;

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnBecameInvisible(){
    	Destroy(gameObject);
    }

	private void OnMouseOver()
	{
		halo.enabled = true;
	}
	private void OnMouseExit()
	{
		halo.enabled = false;
	}
	private void OnMouseDown()
	{
		GameInfo gameInfo = player.GetComponent<GameInfo>();
		gameInfo.x = (int)transform.position.x;
		gameInfo.y = (int)transform.position.y;
		gameInfo.z = (int)transform.position.z;
		SceneManager.LoadScene("StarSystem");
	}
}
