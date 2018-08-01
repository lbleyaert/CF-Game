using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;


namespace DialogueNamespace
{
    public class Dialogue
    {

        public List<DialogueNode> nodes;

        public Dialogue()
        {
            nodes = new List<DialogueNode>();
        }

        /// <summary>
        /// Loads a dialogue from an xml path (must deserialize it in order to cast it as a _Dialogue object)
        /// </summary>
        /// <param name="path">string path to the xml file (which should be in Assets)</param>
        /// <returns>returns the _Dialogue object with information read from the xml file</returns>
        public static Dialogue LoadDialogue(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);

            Dialogue dia = (Dialogue)xmlSerializer.Deserialize(reader);

            return dia;
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
