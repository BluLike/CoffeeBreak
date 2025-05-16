using UnityEngine;
using System.Collections.Generic;

public class InteractiveDialogueBehavior : MonoBehaviour
{
    [SerializeField] List<DialogLine> entityDialogLines;

    [SerializeField] DialogueScript dialogueScript;

    private bool playerInRange = false;
    public bool interacting = false;

    private void Update()
    {
        if (!dialogueScript.canInteract)
        {
            interacting = false;
        }
        else if (playerInRange && Input.GetKeyDown(KeyCode.E) && !interacting)
        {
            interacting = true;
            ActivateDialogue();
        }  
    }
    public void ActivateDialogue()
    {
        if(dialogueScript != null)
        {
            dialogueScript.dialogLines.Clear();

            foreach(var dialogLine in entityDialogLines)
            {
                dialogueScript.dialogLines.Add(dialogLine);
            }

            dialogueScript.StartDialogue();
        }
        else
        {
            Debug.Log("Sistema de Diálogo no asignado al objeto");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange=false;
        }
    }
}
