using UnityEngine;
using System.Collections;

public class NetworkFPS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		if (stream.isWriting) {
			
			Vector3 position = transform.position;
			stream.Serialize(ref position);
			Vector3 rotation = transform.rotation.eulerAngles;
			stream.Serialize(ref rotation);
		} else {
			
			Vector3 position = Vector3.zero;
			stream.Serialize(ref position);
			Vector3 rotation = Vector3.zero;
			stream.Serialize(ref rotation);

			transform.position = position;
			Quaternion fromEuler = new Quaternion();
			fromEuler.eulerAngles = rotation;
			transform.rotation = fromEuler;

		}
	}
}
