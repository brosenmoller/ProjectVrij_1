using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

/* TMPAnimated class based on mixandjam's AC-Dialogue TMPAnimated class
 * https://github.com/mixandjam/AC-Dialogue
 * Edited for use in this project
 */

public class TMPAnimated : TextMeshProUGUI
{
    [Header("Settings")]
    private float speed = 30;

    public UnityEvent onAction;
    public UnityEvent onTextReveal;
    public UnityEvent onDialogueFinish;

    public void ReadText(string newText)
    {
        text = string.Empty;
        // split the whole text into parts based off the <> tags 
        // even numbers in the array are text, odd numbers are tags
        string[] subTexts = newText.Split('<', '>');

        // textmeshpro still needs to parse its built-in tags, so we only include noncustom tags
        string displayText = "";
        for (int i = 0; i < subTexts.Length; i++)
        {
            if (i % 2 == 0)
                displayText += subTexts[i];
            else if (!isCustomTag(subTexts[i].Replace(" ", "")))
                displayText += $"<{subTexts[i]}>";
        }
        // check to see if a tag is our own
        bool isCustomTag(string tag)
        {
            return tag.StartsWith("speed=") || tag.StartsWith("pause=") || tag.StartsWith("action");
        }

        // send that string to textmeshpro and hide all of it, then start reading
        text = displayText;
        maxVisibleCharacters = 0;
        StartCoroutine(Read());

        IEnumerator Read()
        {
            int subCounter = 0;
            int visibleCounter = 0;
            while (subCounter < subTexts.Length)
            {
                // if 
                if (subCounter % 2 == 1)
                {
                    yield return EvaluateTag(subTexts[subCounter].Replace(" ", ""));
                }
                else
                {
                    while (visibleCounter < subTexts[subCounter].Length)
                    {
                        onTextReveal.Invoke();
                        visibleCounter++;
                        maxVisibleCharacters++;
                        yield return new WaitForSeconds(1f / speed);
                    }
                    visibleCounter = 0;
                }
                subCounter++;
            }
            yield return null;

            WaitForSeconds EvaluateTag(string tag)
            {
                if (tag.Length > 0)
                {
                    if (tag.StartsWith("speed="))
                    {
                        speed = float.Parse(tag.Split('=')[1]);
                    }
                    else if (tag.StartsWith("pause="))
                    {
                        return new WaitForSeconds(float.Parse(tag.Split('=')[1]));
                    }             
                    else if (tag.StartsWith("action="))
                    {
                        onAction.Invoke();
                    }
                }
                return null;
            }
            onDialogueFinish.Invoke();
        }
    }
}
