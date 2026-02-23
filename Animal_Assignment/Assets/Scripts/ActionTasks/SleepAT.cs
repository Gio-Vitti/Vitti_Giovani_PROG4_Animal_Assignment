using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

        private NavMeshAgent navAgent;
        public BBParameter<Transform> caveSpot;
		public BBParameter<float> sleep;
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
            navAgent.SetDestination(caveSpot.value.position);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if (Vector3.Distance(agent.transform.position, caveSpot.value.position) <= 0.5)
			{
				agent.transform.eulerAngles = new Vector3(0, 0, 180);
				sleep.value += Time.deltaTime;
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            agent.transform.eulerAngles = Vector3.zero;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}