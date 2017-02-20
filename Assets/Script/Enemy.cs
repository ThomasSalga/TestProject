using UnityEngine;
using System.Collections;

public enum EnemyState { Move, Attack };

public class Enemy : MonoBehaviour {

    #region member

    public EnemyState m_state;
    public int m_atk;
    public float m_atk_speed;
    public float m_speed;
    public int m_life;

    private float m_atkRate;
    private float m_lastAtk;
    Rigidbody2D m_rb;
    GameObject m_target;

    int m_direction;
    GameObject m_player;

    #endregion


    IEnumerator HitFeedback(SpriteRenderer rendererObj)
    {
        Color c;
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            c = rendererObj.color;
            c.g = f;
            c.b = f;
            rendererObj.color = c;
            yield return new WaitForSeconds(.01f);
        }
        rendererObj.color = Color.white;
    }

    void Start ()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_state = EnemyState.Move;

        m_atkRate = 1f / m_atk_speed;
    }
	
	void FixedUpdate ()
    {
        CheckState();
        m_rb.velocity = new Vector2(m_speed * m_direction,0);

        if (m_life <= 0)
        {
            m_player = GameObject.FindGameObjectWithTag("Player");
            m_player.GetComponent<Player>().m_resource++;
            Destroy(gameObject);
        }
    }

    protected void CheckState()
    {
        if (m_target == null)
            m_state = EnemyState.Move;
        switch (m_state)
        {
            case EnemyState.Move:
                EnemyStateMove();
                break;

            case EnemyState.Attack:
                EnemyStateAttack();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Defence")
        {
            m_state = EnemyState.Attack;
            m_target = other.gameObject;
        }
        else if (other.gameObject.tag == "Projectile")
        {
            StartCoroutine(HitFeedback(gameObject.GetComponent<SpriteRenderer>()));
            Destroy(other.gameObject);
            m_life--;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Defence")
            m_state = EnemyState.Move;
    }

    void EnemyStateMove()
    {
        m_direction = (int)transform.right.x;
    }

    void EnemyStateAttack()
    {
        m_direction *= 0; //stops the movement 
        if (Time.time > m_atkRate + m_lastAtk)
        {
            Attack();
            m_lastAtk = Time.time;
        }
    }

    void Attack()
    {
        if (m_target != null)
        {
            m_target.GetComponent<Tower>().m_life--;
            StartCoroutine(HitFeedback(m_target.GetComponent<SpriteRenderer>()));
        }
        else m_state = EnemyState.Move;

    }
}
