using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCScript : MonoBehaviour
{   public NewBehaviourScript player;
    private DialogueRunner dialogueRunner;
    public string conversationStartNode;
    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        
      player.controlFreeze = dialogueRunner.IsDialogueRunning;
       
    }
    
    public void StartConversation()
    {
        dialogueRunner.StartDialogue(conversationStartNode);
    }

   
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKey(KeyCode.E) && !dialogueRunner.IsDialogueRunning)
        {
            // then run this character's conversation
            StartConversation();
            
        }

    }

}
