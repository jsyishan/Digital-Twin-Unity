using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShipAttitude))]
public class TimeScaleUI : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        ShipAttitude ui = (ShipAttitude)target;
        if(GUILayout.Button("Change")) {
            Time.timeScale = ui.time;
        }
    }
}
