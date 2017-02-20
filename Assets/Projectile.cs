using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float m_speed;
    int m_direction;

    Rigidbody2D m_rb;

    // Use this for initialization
    void Start ()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_direction = (int)transform.right.x * -1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        m_rb.velocity = new Vector2(m_speed * m_direction, 0);
    }
}
