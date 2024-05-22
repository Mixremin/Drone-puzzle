using _LevelSpecific;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IEnemy
{
    [SerializeField]
    private float health = 100.0f;
    //[SerializeField]
    //private float pushForce = 30.0f;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private EnemyMovement enemyMovementController;

    //[SerializeField]
    //private GameObject deathVFX;

    private bool dead = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeTick()
    {
        TakeDamage(30f);
    }
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        if (!dead)
        {
            health -= damage;
            Debug.Log("Current health:" + health);
            //Vector3 pushDirection = transform.position - PlayerPos;
            //if (pushDirection.y > 1)
            //{
            //    pushDirection.y = 1.0f;
            //}

            //Debug.DrawLine(transform.position, transform.position + (pushDirection.normalized * 10), Color.red, 5.0f);
            //gameObject.GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            if (health <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        enemyMovementController.DeathRemove();
        dead = true;
        anim.SetTrigger("Death");
    }

    //private void SpawnDeathVFX()
    //{
    //    _ = Instantiate(deathVFX, transform.position, transform.rotation);
    //}

    public void Despawn()
    {
        Destroy(gameObject);
    }


}
