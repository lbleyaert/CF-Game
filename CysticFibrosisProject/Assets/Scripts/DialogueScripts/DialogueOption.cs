using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueNamespace
{
    public class DialogueOption
    {

        public string response;
        public int destinationNodeID;

        //empty constructor
        public DialogueOption()
        {

        }

        public DialogueOption(string response, int dest)
        {
            this.response = response;
            this.destinationNodeID = dest;

        }


    }
}

/*used a tutorial for dialogue structure: 
 * LarsIsGaming 
 * https://www.youtube.com/watch?v=wnhvu99A1tg
 * https://www.youtube.com/watch?v=ILQND0Mb9TQ
 * Used classes (Dialogue, DialogueOption, and DialogueNode) as shown as well as the xml file structure, but created a 
 * scriptable object for controlling the dialogue rather 
 */
