using UnityEngine;
using System.Collections;

public class WanderAI : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    public ParticleSystem ParticleEffect;
    public SkinnedMeshRenderer Skin;
    public bool jumping;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;
     public Color altColor = Color.black;
    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
		{
            if(jumping)
            {
            float baseng = Random.Range (-3f, 9f);
			GetComponent<UnityEngine.AI.NavMeshAgent> ().baseOffset = baseng;
            }
			
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
           // ParticleEffect.Play();
           
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}