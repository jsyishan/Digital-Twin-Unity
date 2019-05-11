using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class RealtimeAttitude : MonoBehaviour {

	private string recvStr;

	private Socket socket;
	private EndPoint serverEnd;
	private IPEndPoint ipEnd;
	private byte[] recvData = new byte[64];
	private byte[] sendData = new byte[64];
	int recvLen = 0;
	Thread connThread;

	private RealtimeDataPacket data;

	public float smoothing = 2.0f;
	public bool enableSmoothing = true;

	void Start () {
		data = new RealtimeDataPacket();
		InitSocket();
	}

	private void OnApplicationQuit() {
		SocketClose();
	}

	private void InitSocket() {
		ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23333);
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

		IPEndPoint sender = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
		serverEnd = (EndPoint) sender;

		// SocketSend("Connection from Unity!");
		socket.Bind(serverEnd);
		connThread = new Thread(new ThreadStart(SocketReceive));
		connThread.Start();
		
	}

	private void SocketSend(string sendStr) {
		sendData = new byte[64];
		sendData = Encoding.ASCII.GetBytes(sendStr);
		socket.SendTo(sendData, sendData.Length, SocketFlags.None, ipEnd);
	}

	private void SocketReceive() {
		while(true) {
			recvData = new byte[64];
			recvLen = socket.ReceiveFrom(recvData, ref serverEnd);

			// Debug.Log("From: " + serverEnd);
			if (recvLen > 0) {
				recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);
				// Debug.Log(recvStr);
				data.setData(recvStr);
				Thread.Sleep(10);
			}
		}
	}

	private void SocketClose() {
		if (connThread != null) {
			connThread.Interrupt();
			connThread.Abort();
		}
		if (socket != null) {
			socket.Close();
		}
	}

	void Update () {
		// Smoothing
		Vector3 p;
		Quaternion q;
		if (enableSmoothing) {
			p = Vector3.Lerp(this.transform.position, new Vector3(data.longitude, data.altitude, data.latitude), Time.deltaTime * smoothing);
			q = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(data.pitch, data.yaw, data.roll), Time.deltaTime * smoothing);
		} else {
			p = new Vector3(data.longitude, data.altitude, data.latitude);
			q = Quaternion.Euler(data.pitch, data.yaw, data.roll);
		}
        this.transform.rotation = q;
        this.transform.position = p;
    }

}
