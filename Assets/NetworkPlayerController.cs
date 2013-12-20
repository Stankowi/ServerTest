using UnityEngine;
using System.Collections;

public class NetworkPlayerController : MonoBehaviour {
	public string networkPlayerGUID;

	float forwardInput = 0;
	float horizontalInput = 0;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		forwardInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");
		Vector3 newPosition = transform.position;
		newPosition += new Vector3(forwardInput*Time.deltaTime*25,0,horizontalInput*Time.deltaTime*25);
		gameObject.transform.position = newPosition;

		//Debug.Log("Update forwardInput " + forwardInput);
		//Debug.Log("Update horizontalInput " + horizontalInput);
		//Vector3 newPosition = transform.position;
		//newPosition += new Vector3(forwardInput*5,0,horizontalInput*5);
		//gameObject.transform.position = newPosition;
		//if(Network.player.guid == networkPlayerGUID) {
			//forwardInput = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
			//horizontalInput = Input.GetKey(KeyCode.A) ? 1 : Input.GetKey(KeyCode.D) ? -1 : 0;
		//}

	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		if (stream.isWriting) {

			Vector3 position = transform.position;
			stream.Serialize(ref position);
		} else {

			Vector3 position = Vector3.zero;
			stream.Serialize(ref position);
			transform.position = position;
		}

	}
}