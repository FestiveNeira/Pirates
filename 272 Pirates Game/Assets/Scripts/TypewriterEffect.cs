using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textLabel;

    private string cutsceneText1 = "You raided the store!\n";
    private string cutsceneText2 = "But obviously,\n you were arrested.\n";
    private string cutsceneText3 = "They can't hold you.";

    [SerializeField]
    private float typeWriterSpeed = 50f;

    private void Start()
    {
        Run(cutsceneText1, textLabel);
    }

    public void Run(string textToType, TMP_Text textLabel)
    {
        StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        yield return new WaitForSeconds(2f);

        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
        Run2(cutsceneText2, textLabel);
    }

    public void Run2(string textToType, TMP_Text textLabel)
    {
        StartCoroutine(TypeText2(textToType, textLabel));
    }

    private IEnumerator TypeText2(string textToType, TMP_Text textLabel)
    {
        yield return new WaitForSeconds(2f);

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
        Run3(cutsceneText3, textLabel);
    }

    public void Run3(string textToType, TMP_Text textLabel)
    {
        StartCoroutine(TypeText3(textToType, textLabel));
    }

    private IEnumerator TypeText3(string textToType, TMP_Text textLabel)
    {
        yield return new WaitForSeconds(2f);

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Level 2");
    }
}
