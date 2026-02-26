using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FishAttackAT : ActionTask {
		public BBParameter<bool> isAttacking;
		public BBParameter<float> fishTimer;
		public Blackboard mainBB;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			isAttacking.value = true;
			mainBB.SetVariableValue("fishAttacking", true);

			//Set position
			agent.GetComponent<SpriteRenderer>().enabled = true;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			

		}

        //Called when the task is disabled.
        protected override void OnStop() {
			fishTimer.value = 10;
			isAttacking.value = false;
            mainBB.SetVariableValue("fishAttacking", false);
            agent.GetComponent<SpriteRenderer>().enabled = false;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}