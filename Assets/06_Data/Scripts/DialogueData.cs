using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue")]
public class DialogueData : ScriptableObject
{
    [Header
    (
        "Extra Setting for text, put the commands into the string as displayed below. " +
        "Dialogue supports multiple magic commands.\n" +
        "'<size=10>', changes text size\n" +
        "'<speed=10>', changed the speed which text is displayed'\n" +
        "'<pause=3>', creates a pause at which the text will stop momentarily\n"
    )]


    [TextArea(4, 4)] public string[] dialogueLines;
    public AudioObject[] associatedAudio;
}
