using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding {
    public class GuardPath : VersionedMonoBehaviour
    {   
		public Transform[] targets;
		private Transform player;
		public bool isStationary;
		public float delay = 0;
		int index;
        IAstarAI agent;
		float switchTime = float.PositiveInfinity;
        Animator animator;

        [SerializeField] private float startingX = 0f;
	    [SerializeField] private float startingY = 0f;

        protected override void Awake()
		{
			base.Awake();
			agent = GetComponent<IAstarAI>();
			index = Random.Range(0, targets.Length);
			player = GameObject.FindGameObjectWithTag("Player").transform;
            animator = GetComponentInChildren<Animator>();
            if (isStationary) {
                animator.SetBool("patrolling", false);
                animator.SetBool("isStationary", true);
                animator.SetFloat("moveX", startingX);
                animator.SetFloat("moveY", startingY);
            }
		}

        public void SetPath()
        {
            agent.destination = player.position;
            agent.SearchPath();
        }

        public void Patrol()
		{   
			if (targets.Length == 0 || isStationary) return;
			bool search = false;
			
			if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
			{
				animator.SetBool("patrolling", false);
				switchTime = Time.time + delay;
			}

			if (Time.time >= switchTime)
			{
				index = Random.Range(0, targets.Length);
				search = true;
				switchTime = float.PositiveInfinity;
				animator.SetBool("patrolling", true);
			}

			agent.destination = targets[index].position;
			animator.SetFloat("moveX", targets[index].position.x - agent.position.x);
			animator.SetFloat("moveY", targets[index].position.y - agent.position.y);
			if (search) agent.SearchPath();
		}

        public void DisableMove()
        {
            agent.isStopped = true;
        }

        public void EnableMove()
        {
            agent.isStopped = false;
        }

        public Vector3 GetAIVelocity()
        {
            return agent.desiredVelocity;
        }


        public void Teleport(Vector3 position)
        {
            agent.Teleport(position, true);
            DisableMove();
        }


    }

    
}
