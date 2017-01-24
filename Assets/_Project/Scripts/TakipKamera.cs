using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class TakipKamera : MonoBehaviour
	{
        public GameObject arac1;
        public GameObject arac2;
        public GameObject arac3;
        public GameObject arac4;
        public GameObject arac5;
        public GameObject arac6;
       


        // The target we are following
        private Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;

		// Use this for initialization
		public void aracSec() {
            AracKontrol arac1script = arac1.GetComponent<AracKontrol>();
            AracKontrol arac2script = arac2.GetComponent<AracKontrol>();
            AracKontrol arac3script = arac3.GetComponent<AracKontrol>();
            AracKontrol arac4script = arac4.GetComponent<AracKontrol>();
            AracKontrol arac5script = arac5.GetComponent<AracKontrol>();
            AracKontrol arac6script = arac6.GetComponent<AracKontrol>();


            if (arac1script.akliVarmi == false)
            {
                target = arac1.transform;
              
            }

            else if (arac2script.akliVarmi == false)
            {
                target = arac2.transform;
              
            }
            else if (arac3script.akliVarmi == false)
            {
                target = arac3.transform;
            
            }
            else if (arac4script.akliVarmi == false)
            {
                target = arac4.transform;
               
            }
            else if (arac5script.akliVarmi == false)
            {
                target = arac5.transform;
               
            }
            else if (arac6script.akliVarmi == false)
            {
                target = arac6.transform;
              
            }
     


        }

        // Update is called once per frame
        void LateUpdate()
        {


            // Early out if we don't have a target
            if (!target)
				return;

			// Calculate the current rotation angles
			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);
		}
	}
}
