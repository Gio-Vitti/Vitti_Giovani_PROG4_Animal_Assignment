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
        private NavMeshAgent navAgent;
       

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
			StartCoroutine(moveCycle());
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		IEnumerator moveCycle()
		{
            yield return new WaitForSeconds(waitTime);
            WanderAround();
			
		}

       private void WanderAround()
		{
            navAgent.SetDestination(newDestination(distance));
			StartCoroutine(moveCycle());
        }

		private Vector3 newDestination(float distance) //Get a random angle for the character to move towards
		{
			//Get angle
			float angleRad = (Random.Range(0, 360) * Mathf.Deg2Rad);
            Debug.Log(angleRad);
            float x = Mathf.Cos(angleRad) * Random.Range(-1,2);
            float z = Mathf.Sin(angleRad) * Random.Range(-1, 2);

			Vector3 dest = ((agent.transform.position + new Vector3(x, 0, z)).normalized * distance);

            //set distance
            return (dest);
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}