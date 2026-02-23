using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {
		public float waitTime;
		public float distance;
		private Vector3 destination;
        private NavMeshAgent navAgent;
		public LayerMask ground;
       

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			navAgent = agent.GetComponent<NavMeshAgent>();
            navAgent.SetDestination(newDestination(distance));
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			//Resets move cycle when stopped
            if (Vector3.Distance(agent.transform.position, destination) <= 0.3 && navAgent.isStopped == false) {

                navAgent.isStopped = true;
                StartCoroutine(MoveCycle());
			}

			//Prevents animal from getting stuck in corners
			if (Physics.Raycast(agent.transform.position, agent.transform.forward, 0.1f, ground))
			{
				destination = -agent.transform.forward;
                StartCoroutine(MoveCycle());
            }
		}

		IEnumerator MoveCycle()
		{
            yield return new WaitForSeconds(waitTime);
            navAgent.isStopped = false;
            navAgent.SetDestination(newDestination(distance));
        }

		private Vector3 newDestination(float distance) //Get a random angle for the character to move towards
		{
			//Get angle
			float angleRad = (Random.Range(0, 360) * Mathf.Deg2Rad);
         
			float x = Mathf.Cos(angleRad);
			float z = Mathf.Sin(angleRad);

			destination = ((agent.transform.forward + new Vector3(x, 0, z)).normalized * distance);

            //set distance
            return (destination);
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}