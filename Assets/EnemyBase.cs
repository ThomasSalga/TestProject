using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject[] listEnemy;
        listEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (listEnemy.Length == 0)
            SceneManager.LoadScene("WinScene");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
