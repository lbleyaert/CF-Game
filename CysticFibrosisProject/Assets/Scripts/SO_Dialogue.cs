using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Dialogue : ScriptableObject {

    [TextArea(3, 10)]
    public string[] sentences;
    //boolean telling whether or not the dialogue is followed by a scene change
    public bool isSceneChange;


}
