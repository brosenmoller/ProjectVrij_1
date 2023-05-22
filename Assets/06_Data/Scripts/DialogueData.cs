using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue")]
public class DialogueData : ScriptableObject
{
    [TextArea(4, 1000)]
    [Tooltip("Extra Setting for text, put the commands into the string as displayed below.")]
    public string Notes = 
        "Dialogue supports multiple magic commands.\n" +
        "'<size=10>', changes text size\n" +
        "'<speed=10>', changed the speed which text is displayed'\n" +
        "'<pause=3>', creates a pause at which the text will stop momentarily\n";

    [TextArea(4, 4)] public List<string> dialogueLines;
    public List<AudioObject> associatedAudioClips;
}
