using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ShipAttitude : MonoBehaviour {

    private struct AttitudeData {
        public int   Timestamp { get; set; }
        public float Roll      { get; set; }
        public float Pitch     { get; set; }
        public float Yaw       { get; set; }
    }

    private struct GpsData {
        public int   Timestamp { get; set; }
        public float Latitude  { get; set; }
        public float Longitude { get; set; }
        public float Altitude  { get; set; }
    }

    private List<AttitudeData> attitudeData;
    private List<GpsData> gpsData;

    [Range(0, 60000)]
    public int att = 0;
    [Range(0, 6000)]
    public int gps = 0;

    [Range(0.0f, 100.0f)]
    public float time = 1.0f;

    private float attTimer = 0.0f;
    private int gpsCounter = 0;

    void Start () {
        attitudeData = new List<AttitudeData>();
        gpsData = new List<GpsData>();

        StreamReader attitudeStreamReader = GetFileStream("result.ahr2");
        string line = attitudeStreamReader.ReadLine();
        string[] dt = line.Split(' ');
        while (line != null) {
            AttitudeData d = new AttitudeData {
                Timestamp =   int.Parse(dt[0]),
                Roll      = float.Parse(dt[1]),
                Pitch     = float.Parse(dt[2]),
                Yaw       = float.Parse(dt[3])
            };
            attitudeData.Add(d);
            line = attitudeStreamReader.ReadLine();
            if (line != null)
                dt = line.Split(' ');
        }
        attitudeStreamReader.Close();

        StreamReader gpsStreamReader = GetFileStream("result.gps");
        line = gpsStreamReader.ReadLine();
        dt = line.Split(' ');
        while (line != null) {
            GpsData d = new GpsData {
                Timestamp =   int.Parse(dt[0]),
                Latitude  = float.Parse(dt[1]),
                Longitude = float.Parse(dt[2]),
                Altitude  = float.Parse(dt[3])
            };
            gpsData.Add(d);
            line = gpsStreamReader.ReadLine();
            if (line != null)
                dt = line.Split(' ');
        }
        gpsStreamReader.Close();

        Vector3 offset = new Vector3(-0.362f, 0.288f, 1.83f);
        for(int i = 0; i < gpsData.Count - 1; i++) {
            Debug.DrawLine(new Vector3(gpsData[i].Longitude, gpsData[i].Altitude, gpsData[i].Latitude),
                           new Vector3(gpsData[i+1].Longitude, gpsData[i+1].Altitude, gpsData[i+1].Latitude), Color.red, 3000.0f);
        }
    }

    StreamReader GetFileStream(string filename) {
        string fileName = "";
        #if UNITY_IPHONE
            string fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
            fileName = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/AttitudeData/" + filename;
        #elif UNITY_ANDROID
            fileName = Application.persistentDataPath + "/AttitudeData/" + filename ;
        #else
        fileName = Application.dataPath + "/AttitudeData/" + filename;
        #endif

        StreamReader streamReader = new StreamReader(fileName);
        return streamReader;
    }

    void FixedUpdate () {
        if (attTimer >= 0.02f) {
            this.transform.eulerAngles = new Vector3(attitudeData[att+410].Pitch, attitudeData[att+410].Yaw, attitudeData[att+410].Roll);
            att++;
            gpsCounter++;
            if (gpsCounter == 10) {
                this.transform.position = new Vector3(gpsData[gps].Longitude, gpsData[gps].Altitude, gpsData[gps].Latitude);
                gps++;
                gpsCounter = 0;
            }
            attTimer = 0.0f;
            //Debug.Log(ts + ": " + data[ts].Pitch + " " + data[ts].Yaw + " " + data[ts].Roll);
        }
        attTimer += Time.fixedDeltaTime;
    }
}
