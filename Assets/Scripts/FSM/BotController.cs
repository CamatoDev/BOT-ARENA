using UnityEngine;
using Pathfinding;

public class BotController : MonoBehaviour
{
    public BotStateMachine StateMachine { get; private set; }
    public AIDestinationSetter destinationSetter;
    public Transform[] patrolPoints;

    public Transform enemyTarget;
    public int Health = 100;
    public int Ammo = 5;
    public int MaxAmmo = 5;

    public float visionRange = 10f;
    public float fleeThreshold = 25f;

    void Awake()
    {
        StateMachine = GetComponent<BotStateMachine>();
    }

    void Start()
    {
        StateMachine.ChangeState(new PatrolState(this));
    }

    void Update()
    {
        // Logique générale ?
    }

    public bool IsAtDestination()
    {
        return Vector3.Distance(transform.position, destinationSetter.target.position) < 0.5f;
    }

    public void SetRandomPatrolPoint()
    {
        destinationSetter.target = patrolPoints[Random.Range(0, patrolPoints.Length)];
    }

    public bool CanSeeEnemy()
    {
        if (enemyTarget == null) return false;
        return Vector3.Distance(transform.position, enemyTarget.position) <= visionRange;
    }

    public void SetTarget(Transform t)
    {
        destinationSetter.target = t;
    }

    public void Shoot()
    {
        Debug.Log("Bot SHOOTS 🔫");
        Ammo--;
    }

    public void Reload()
    {
        Debug.Log("Bot is RELOADING 🔄");
        Ammo = MaxAmmo;
    }

    public void Flee()
    {
        Debug.Log("Bot is FLEEING 🏃‍♂️");
        // Va au point le plus éloigné de l'ennemi
        if (patrolPoints.Length == 0) return;
        Transform farthest = patrolPoints[0];
        float maxDist = 0;
        foreach (var point in patrolPoints)
        {
            float dist = Vector3.Distance(enemyTarget.position, point.position);
            if (dist > maxDist)
            {
                maxDist = dist;
                farthest = point;
            }
        }
        destinationSetter.target = farthest;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}