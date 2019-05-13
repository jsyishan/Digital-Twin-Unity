using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RealtimeDataPacket  {

	public float firstLon;	
	public float firstAlt;
	public float firstLat;

	public float pitch;
	public float yaw;
	public float roll;
	public float longitude;
	public float altitude;
	public float latitude;
	public float speed;
	public int seq;

	private bool first = true;
	private float _lon;
	private float _lat;
	private float _alt;

	public RealtimeDataPacket() {

	}
	
// Copy constructor
	public RealtimeDataPacket(RealtimeDataPacket packet) {
		pitch 		= packet.pitch;
		yaw 		= packet.yaw;
		roll 		= packet.roll;
		longitude 	= packet.longitude;
		altitude 	= packet.altitude;
		latitude 	= packet.latitude;
		speed 		= packet.speed;
		seq 		= packet.seq;
	}

	public void setData(string rawData) {
		string[] datas = rawData.Split(' ');

		pitch = float.Parse(datas[0]);
		yaw = float.Parse(datas[1]);
		roll = float.Parse(datas[2]);
		
		// private memebers just for sroraging raw data of GPS info
		_lon = float.Parse(datas[3]);
		_alt = float.Parse(datas[4]);
		_lat = float.Parse(datas[5]);

		float lon = int.Parse(datas[3].Split('.')[1].Substring(2)) / 1000.0f;
		float alt = float.Parse(datas[4]) / 10.0f;
		float lat = int.Parse(datas[5].Split('.')[1].Substring(2)) / -1000.0f;
		speed = float.Parse(datas[6]);
		seq = int.Parse(datas[7]);

		if (first) {
			firstLon = lon;
			firstAlt = alt;
			firstLat = lat;
			first = false;
		}

		longitude = lon - firstLon;
		altitude = alt - firstAlt;
		latitude = lat - firstLat;
	}

	public override string ToString() {
		return "Sequence: " + seq + " Pitch: " + pitch + " Yaw: " + yaw + " Roll: " + roll + " Longitude: " + _lon + " Altitude: " + _alt + " Latitude: " + _lat + " Speed: " + speed + '\n';  
	}
	
}
