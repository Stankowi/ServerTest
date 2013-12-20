using UnityEngine;
using System.Collections;

public class ClientTest : MonoBehaviour {
	bool connected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUILayout.Label("Client...");
		if(connected) {
			GUILayout.Label("Connected!");
		}
		else {
			if(GUILayout.Button("Connect")) {
				Network.Connect("127.0.0.1", 25000, "ThisIsTheBestPassword");
			}
		}
		GUILayout.Label(string.Format("{0} connections",Network.connections.Length));
		GUILayout.Label(Network.player.guid);
	}
	
	void OnConnectedToServer() {
		connected = true;
		GameObject fps = GameObject.Instantiate(Resources.Load("First Person Controller"),
		                                        new Vector3(0,2,0),
		                                        Quaternion.identity) as GameObject;

		GameObject go = Network.Instantiate(Resources.Load("FPSNetwork"),
		                    new Vector3(0,2,0),
		                    Quaternion.identity,
		                    0) as GameObject;

		go.transform.parent = fps.transform;
	}
	
	
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		connected = false;
	}
}
