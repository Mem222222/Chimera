using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Triggerscript : MonoBehaviour
{ 
    public TMP_Text Area_Text;
public TMP_Text Intro_Text;
public string Txt_Prmpt;
public string intro;
public static bool skip_intro;
// Start is called before the first frame update
void Start()
{

    
}
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Area_Tag")
    {
        Txt_Prmpt = collision.gameObject.name;
        StartCoroutine(DelayedAction());
    }
    if (collision.gameObject.tag == "NPC")
    {
        Txt_Prmpt = "Press E";
        if (Input.GetKey(KeyCode.E))
        {
            Txt_Prmpt = "";
        }
    }
    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(2f);
        Txt_Prmpt = "";
    }
}
private void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.tag == "NPC" && Input.GetKey(KeyCode.E))
    {
        Txt_Prmpt = "";
    }
}
private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.tag == "NPC")
    {
        Txt_Prmpt = "";
    }
}
void Update()
{
    Intro_Text.SetText(intro);
    Area_Text.SetText(Txt_Prmpt);
    if (Input.GetKey(KeyCode.E) && tag == "NPC")
    {
        Txt_Prmpt = "";
    }
}
}
