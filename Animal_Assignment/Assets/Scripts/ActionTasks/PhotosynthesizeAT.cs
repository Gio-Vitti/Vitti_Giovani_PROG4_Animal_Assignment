using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PhotosynthesizeAT : ActionTask {

		private NavMeshAgent navAgent;
		public BBParameter<Transform> lightSpot;
		public BBParameter<float> light;
		private Light shine;

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
			navAgent.SetDestination(lightSpot.value.position);
			shine = agent.GetComponent<Light>();
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if(Vector3.Distance(agent.transform.position, lightSpot.value.position) <= 1 && light.value < 10)
			{
				light.value += Time.deltaTime;
				agent.transform.Rotate(0, 1, 0);
				shine.enabled = true;

			} 
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            shine.enabled = false;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}