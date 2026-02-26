using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PlayAT : ActionTask {

        public LayerMask ballLayer;
        public BBParameter<float> fun;
        private NavMeshAgent navAgent;
		public BBParameter<bool> ballKicked;

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
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            Collider[] ball = Physics.OverlapSphere(agent.transform.position, 100, ballLayer);
            navAgent.SetDestination(ball[0].transform.position);

            if (Physics.Raycast(agent.transform.position, agent.transform.forward, 0.5f, ballLayer))
            {
				ball[0].GetComponent<Rigidbody>().AddForce((navAgent.transform.forward + Vector3.up) * 4, ForceMode.Impulse);
				ballKicked.value = true;
				EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			fun.value += 5;
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}