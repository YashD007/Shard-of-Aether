using UnityEngine;


public class Duymmy : MonoBehaviour

{
public SPUM_Prefabs sP;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sP.OverrideControllerInit();
    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.E))
        {
            sP.PlayAnimation(PlayerState.ATTACK, 0);
        }
            }
}
