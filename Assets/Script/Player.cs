using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int m_life;
    public int m_resource;

	// Use this for initialization
	void Start ()
    {
        m_life = 2;
        m_resource = 1;
	}
	
	// Update is called once per frame
	void Update () {
	   if(m_life <=0)
        {
            SceneManager.LoadScene("DeadScene");
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        m_life--;
    }
}
