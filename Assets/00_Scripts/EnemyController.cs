using UnityEngine;
using UnityEngine.AI; // Necesario para utilizar NavMeshAgent


public class EnemyController : MonoBehaviour
{
   // Referencia al agente de NavMesh
   private NavMeshAgent agent;


   // Puntos de patrulla a través de un Array
   [SerializeField] private Transform[] waypoints;
   private int currentWaypointIndex = 0;


   // Distancia mínima para cambiar al siguiente waypoint
   [SerializeField] private float waypointThreshold = 1f;


   // Referencia al jugador
   private Transform playerTransform;


   // Rango de detección
   [SerializeField] private float detectionRange = 10f;


   // Rango de ataque
   [SerializeField] private float attackRange = 2f;


   // Daño al jugador
   [SerializeField] private int damageAmount = 10;


   // Tiempo entre ataques
   [SerializeField] private float attackCooldown = 2f;
   private float lastAttackTime;


   // Estados del enemigo utilizando enum
   private enum EnemyState { Patrol, Chase, Attack }
   private EnemyState currentState = EnemyState.Patrol;


   private void Start()
   {
       // Obtener el NavMeshAgent
       agent = GetComponent<NavMeshAgent>();


       // Obtener la referencia al jugador
       GameObject player = GameObject.FindWithTag("Player");
       if (player != null)
       {
           playerTransform = player.transform;
       }
       else
       {
           Debug.LogError("Jugador no encontrado. Asegúrate de que el jugador tiene el tag 'Player'.");
       }


       // Comenzar patrullaje
       MoveToNextWaypoint();
   }


   private void Update()
   {
       switch (currentState)
       {
           case EnemyState.Patrol:
               Patrol();
               // Si el jugador está dentro del rango de detección, cambiar a estado de persecución
               if (Vector3.Distance(transform.position, playerTransform.position) <= detectionRange)
               {
                   currentState = EnemyState.Chase;
               }
               break;


           case EnemyState.Chase:
               ChasePlayer();
               // Si el jugador está fuera del rango de detección, volver a patrullar
               if (Vector3.Distance(transform.position, playerTransform.position) > detectionRange)
               {
                   currentState = EnemyState.Patrol;
                   MoveToNextWaypoint();
               }
               // Si el jugador está dentro del rango de ataque, cambiar a estado de ataque
               else if (Vector3.Distance(transform.position, playerTransform.position) <= attackRange)
               {
                   currentState = EnemyState.Attack;
               }
               break;


           case EnemyState.Attack:
               AttackPlayer();
               // Si el jugador se aleja del rango de ataque, volver a perseguir
               if (Vector3.Distance(transform.position, playerTransform.position) > attackRange)
               {
                   currentState = EnemyState.Chase;
               }
               break;
       }
   }


   // Método para patrullar entre waypoints
   private void Patrol()
   {
       if (agent.remainingDistance < waypointThreshold)
       {
           MoveToNextWaypoint();
       }
   }


   // Ir al siguiente waypoint
   private void MoveToNextWaypoint()
   {
       if (waypoints.Length == 0)
           return;


       agent.SetDestination(waypoints[currentWaypointIndex].position);
       currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
   }


   // Perseguir al jugador
   private void ChasePlayer()
   {
       agent.SetDestination(playerTransform.position);
   }


   // Atacar al jugador
   private void AttackPlayer()
   {
       agent.SetDestination(transform.position); // Detener al enemigo


       // Mirar hacia el jugador
       Vector3 direction = (playerTransform.position - transform.position).normalized;
       Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
       transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


       // Verificar si puede atacar
       if (Time.time - lastAttackTime >= attackCooldown)
       {
           // Atacar al jugador
           GameManager.instance.Damage(damageAmount);
           Debug.Log("El enemigo ha atacado al jugador.");


           // Actualizar el tiempo del último ataque
           lastAttackTime = Time.time;
       }
   }


   // Visualizar rangos en la vista de escena
   private void OnDrawGizmosSelected()
   {
       // Rango de detección
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, detectionRange);


       // Rango de ataque
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, attackRange);
   }
}

