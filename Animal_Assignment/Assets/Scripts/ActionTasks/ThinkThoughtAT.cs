using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ThinkThoughtAT : ActionTask {

		public BBParameter<GameObject> thoughtBubble;
		public BBParameter<Transform> bubbleTransform;
		private float time = 0;

		private GameObject burger;
		private GameObject light;
		private GameObject ball;
		private GameObject zzz;
		private GameObject surprise;

		//enable icon
		public bool enableBurger;
		public bool enableLight;
		public bool enableBall;
		public bool enableZzz;
		public bool enableSurprise;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {



			//get children
			burger = thoughtBubble.value.transform.GetChild(0).gameObject;
            light = thoughtBubble.value.transform.GetChild(1).gameObject;
            ball = thoughtBubble.value.transform.GetChild(2).gameObject;
            zzz = thoughtBubble.value.transform.GetChild(3).gameObject;
			surprise = thoughtBubble.value.transform.GetChild(4).gameObject;

			//enable objects
			burger.SetActive(enableBurger);
			light.SetActive(enableLight);
			ball.SetActive(enableBall);
			zzz.SetActive(enableZzz);
			surprise.SetActive(enableSurprise);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            bubbleTransform.value.position = agent.transform.position + Vector3.up;
            thoughtBubble.value.transform.position = bubbleTransform.value.position;

        }

		//Called when the task is disabled.
		protected override void OnStop() {
            Object.Destroy(thoughtBubble.value);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}