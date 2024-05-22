using UnityEngine;

public class EnemyRangeCombat : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [Header("Attack Stats")]
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float projSpeed = 2.0f;

    [SerializeField]
    private float attackRate = 2.0f;


    [Header("Attack controllers")]
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private GameObject player;

    private float nextAttacktime = 0f;



    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Attack()
    {
        if (Time.time >= nextAttacktime)
        {
            CombatLogic();
        }
    }

    private void CombatLogic()
    {
        anim.SetTrigger("Attack");

        nextAttacktime = Time.time + (1f / attackRate);
    }

    public void ApplyDamage()
    {
        Vector3 PlayerDir = player.transform.position + new Vector3(0, 1f, 0) - attackPoint.transform.position;

        Rigidbody rb = Instantiate(projectile, attackPoint.transform.position, transform.rotation).GetComponent<Rigidbody>();

        rb.AddForce(PlayerDir * projSpeed, ForceMode.Impulse);

        Destroy(rb.gameObject, 1f);
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.green;
    }

    //public float GetAttackRange()
    //{
    //    return attackRange;
    //}

    //public void SetAttackRange(float newRange)
    //{
    //    attackRange = newRange;
    //}
}
