using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Image spriteComponent;
    private Animator animator;

    public bool dialoguing = false;
    public bool canInteract = false;
    

    public List<DialogLine> dialogLines;
    [SerializeField] float textSpeed;

    public int index;


    private void Start()
    {
        animator = GetComponent<Animator>();
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (dialoguing)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
            {
                if (textComponent.text == dialogLines[index].Text)
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = dialogLines[index].Text;
                }
            }
        }
    }
    public void StartDialogue()
    {
        // dialoguing = true;
        textComponent.text = string.Empty;
        playerMovement.canMove = false;
        animator.SetTrigger("StartDialogue");
        index = 0;
        spriteComponent.sprite = dialogLines[index].Sprite;
        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        if(index < dialogLines.Count - 1)
        {
            index++;
            spriteComponent.sprite = dialogLines[index].Sprite;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            animator.SetTrigger("EndDialogue");
            // dialoguing = false;
            playerMovement.canMove = true;
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in dialogLines[index].Text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

[System.Serializable]
public class DialogLine
{
    public string Text;
    public Sprite Sprite;

    public DialogLine(string text, Sprite sprite)
    {
        Text = text;
        Sprite = sprite;
    }
}
