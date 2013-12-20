using UnityEngine;
using System.Collections;

public class HostOrClient : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if(GUILayout.Button("Host")) {
			gameObject.AddComponent<HostTest>();
			Destroy (this);
		}
		if(GUILayout.Button("Client")) {
			gameObject.AddComponent<ClientTest>();
			Destroy (this);

		}
	}
}
