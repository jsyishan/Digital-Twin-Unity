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

	private bool first = true;

	public RealtimeDataPacket() {

	}

	public void setData(string rawData) {
		string[] datas = rawData.Split(' ');

		pitch = float.Parse(datas[0]);
		yaw = float.Parse(datas[1]);
		roll = float.Parse(datas[2]);

		float lon = int.Parse(datas[3].Split('.')[1].Substring(2)) / 1000.0f;
		float alt = float.Parse(datas[4]) / 10.0f;
		float lat = int.Parse(datas[5].Split('.')[1].Substring(2)) / -1000.0f;

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
	
}
