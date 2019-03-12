using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MavlinkTest : MonoBehaviour {

    MavLink.Mavlink mavlink;
    // Use this for initialization
    void Start () {
        mavlink = new MavLink.Mavlink();
        byte[] bytes = GetStreamBytes("C:\\Users\\Eugen\\Desktop\\test.BIN");
        mavlink.ParseBytes(bytes);
        //Debug.Log(mavlink.Deserialize(bytes, 0));
    }

    // Update is called once per frame
    void Update () {
		
	}

    public byte[] GetStreamBytes(string path) {
        try {
            FileStream stream = new FileInfo(path).OpenRead();
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, System.Convert.ToInt32(stream.Length));
            stream.Close();
            stream.Dispose();
            return buffer;
        } catch (System.Exception ex) {
            Debug.Log(ex.Message);
        }
        return null;
    }
}
