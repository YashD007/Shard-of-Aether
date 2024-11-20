using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public GameObject Idle;
    public GameObject Run;
    private bool isIdleActive = true;
    
    void Start(){
        SwitchCharacter();
    }
    
    void Update()
    {   
        SpriteRenderer spriteRenderer = Run.GetComponent<SpriteRenderer>();

        if (Input.GetKeyDown(KeyCode.A)){
            isIdleActive = false;
            spriteRenderer.flipX = true;
            SwitchCharacter();
        }
        if (Input.GetKeyUp(KeyCode.A)){
            isIdleActive = true;
            spriteRenderer.flipX = false;
            SwitchCharacter();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isIdleActive = false;
            SwitchCharacter();
        }
        if (Input.GetKeyUp(KeyCode.D)){
            isIdleActive = true;
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // isIdleActive = !isIdleActive;

        Idle.SetActive(isIdleActive);
        Run.SetActive(!isIdleActive);

        // Optionally trigger the "isRunning" animation on the newly activated character
        if (isIdleActive)
        {
            Idle.GetComponent<Animator>().SetTrigger("idle");
        }
        else
        {
            Run.GetComponent<Animator>().SetTrigger("isRunning");
        }
    }
}
