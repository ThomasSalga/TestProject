using UnityEngine;
using System.Collections;

public enum DefenceState { ToPlace, Placed };

public class Tower : MonoBehaviour {

    #region member

    public DefenceState m_state;
    public bool snappable;
    public float m_roundsPerSecond;
    public int m_life;

    private float m_fireRate;
    private float m_lastShot;
    Vector3 m_snapHere;
    GameObject m_player;
    #endregion


    IEnumerator SelectedFeedback(SpriteRenderer rendererObj)
    {
        Color c;
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            c = rendererObj.color;
            c.r = f;
            c.b = f;
            rendererObj.color = c;
            yield return new WaitForSeconds(.01f);
        }
        rendererObj.color = Color.white;
    }

    

    void Start()
    {
        m_state = DefenceState.ToPlace;
        m_fireRate = 1f / m_roundsPerSecond;
    }

    protected void Update()
    {
        CheckState();

        if (m_life <= 0)
            Destroy(gameObject);

        if (Time.time > m_fireRate + m_lastShot)
        {
            Shoot();
            m_lastShot = Time.time;
        }
    }

    

    protected void CheckState()
    {
        switch (m_state)
        {
            case DefenceState.ToPlace:
                m_player = GameObject.FindGameObjectWithTag("Player");
                if (m_player.GetComponent<Player>().m_resource == 0)
                    Destroy(gameObject);
                transform.position = Drag();
                DefenceStateToPlace();
                break;

            case DefenceState.Placed:
                DefenceStatePlaced();
                break;
        }
    }

    void DefenceStateToPlace()
    {
        if (Input.GetButtonDown("Fire1") && snappable)
        {
            m_state = DefenceState.Placed;
            transform.position = m_snapHere;

            m_player.GetComponent<Player>().m_resource--;
        }
    }

    void DefenceStatePlaced()
    {
        tag = "Defence";
        transform.position = m_snapHere;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Snap")
        {
            StartCoroutine(SelectedFeedback(other.gameObject.GetComponent<SpriteRenderer>()));
            if (!other.GetComponent<Cell>().m_blocked)
            {
                m_snapHere = other.transform.position;
                m_snapHere.z = 0;

                other.GetComponent<Cell>().m_blocked = true;
                snappable = true;
            }
        }
        
        
    }

    Vector3 Drag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    protected void Shoot()
    {
        if(m_state == DefenceState.Placed)
            GetComponent<SpawnGO>().Spawn();
    }


    }
