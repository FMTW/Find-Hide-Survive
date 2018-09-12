using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]

public class FOWEditor : Editor {

    void OnSceneGUI() {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.left, Vector3.forward, 360, fow.viewRadius);
    }
}
