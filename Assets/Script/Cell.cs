using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    #region member

    public int m_cellHeight;
    public int m_cellLenght;

    public bool m_blocked;
    #endregion

    // Use this for initialization
    void Start ()
    {
        //transform.localScale = new Vector3((float)0.1, (float)0.08, 1);
        m_blocked = false;
    }

    // Update is called once per frame
    void Update ()
    {
	    
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Defence")
            if (other.GetComponent<Tower>().m_state == DefenceState.Placed)
            {
                m_blocked = true;
            }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_blocked = false;
    }

}
