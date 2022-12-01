using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float ChaseRange = 3f;
    [SerializeField] float RoateSpeed = 10f;
    [SerializeField] List<GameObject> dropItems = new List<GameObject>();

    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;
    bool isdying = false;

    Animator animator;
    HuntedRecord huntedRecord;

    NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        huntedRecord = FindObjectOfType<HuntedRecord>();
    }

    void Update()
    {
        if (target == null) { return; }
        distanceToTarget = Vector3.Distance(target.transform.position, this.transform.position);

        if (isdying)
        {
            this.enabled = false;
            navMeshAgent.enabled = false;
        }
        if (isProvoked && !isdying)
        {
            EngageTarget();
        }
        else if (distanceToTarget < ChaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("Attacking", false);
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance + 0.5f)

        {
            AttackTarget();
        }
    }
    public void OnDamageTake()
    {
        isProvoked = true;
    }

    private void AttackTarget()
    {
        animator.SetBool("Attacking", true);
    }

    private void ChaseTarget()
    {
        if (target == null) { return; }
        navMeshAgent.SetDestination(target.position);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, ChaseRange);
    }

    //Call by Animation
    public void DetectiveDying(bool dying)
    {
        int dice = Random.Range(0, 100);
        print(dice);
        if (dice > 50)
        {
            Vector3 dropPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            int index = Random.Range(0, dropItems.Count);
            Instantiate(dropItems[index], dropPos, Quaternion.identity);
        }
        huntedRecord.AddTheNumber();
        isdying = dying;
    }

    private void FaceTarget()
    {
        Vector3 LookAtTarget = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        Vector3 RotateDirectly = LookAtTarget - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(RotateDirectly), RoateSpeed * Time.deltaTime);
    }
}
