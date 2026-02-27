using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

    public class EatAT : ActionTask {

		public LayerMask burgerLayer;
		public BBParameter<float> food;
        private NavMeshAgent navAgent;
        public GameObject foodTxt;

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
			foodTxt.SetActive(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			//Search for burger
			Collider[] burger = Physics.OverlapSphere(agent.transform.position, 100, burgerLayer);
			navAgent.SetDestination(burger[0].transform.position);
           

            //Eat that burger
            if (Physics.Raycast(agent.transform.position, agent.transform.forward, 1, burgerLayer))
			{			
                food.value = 10;
				Object.Destroy(burger[0].gameObject);
			}
		}

		
		//Called when the task is disabled.
		protected override void OnStop() {
            foodTxt.SetActive(false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}