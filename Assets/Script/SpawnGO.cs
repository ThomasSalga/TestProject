using UnityEngine;
using System.Collections;

public class SpawnGO : MonoBehaviour {


    public GameObject m_GO;
    
    public void Spawn()
    {
        GameObject go = (GameObject)Instantiate(m_GO, transform.position, Quaternion.identity);
    }
}
