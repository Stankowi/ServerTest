using UnityEngine;
using System.Collections;

public class HostTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Network.incomingPassword = "ThisIsTheBestPassword";
		var useNat = true;//!Network.HavePublicAddress();
		Network.InitializeServer(32, 25000, useNat);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUILayout.Label("Hosting Server...");
		GUILayout.Label(string.Format("{0} connections",Network.connections.Length));
	}

	
	void OnPlayerConnected(NetworkPlayer player) {
		//player.
	}

	
	void OnPlayerDisconnected(NetworkPlayer player) {
		Network.RemoveRPCs(player);		
		Network.DestroyPlayerObjects(player);
	}
}
