using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//doesn't inherit from MonoBehavior - won't be attached to a gameObject
//serializable so we can see it in the inspector
[System.Serializable]
public class Dialogue {

  //  public string dialogueName;
    [TextArea(3,10)]
    public string[] sentences;


}
