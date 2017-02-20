using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeResource : MonoBehaviour {


    GameObject m_player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<Text>().text = "Resource= " + m_player.GetComponent<Player>().m_resource + "  " +
                                          "Life= " + m_player.GetComponent<Player>().m_life;

    }
}
