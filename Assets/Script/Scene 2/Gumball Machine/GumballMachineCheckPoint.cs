using UnityEngine;
using System.Collections;

public class GumballMachineCheckPoint : MonoBehaviour {

    public int TotalGumballs;
    public GameObject Gumball;
    private int CurrentGumballCount = 0;
    public Animator GumballMachineAnimator;

    void OnTriggerEnter(Collider Object)
    {
        if (Object.tag.Equals("Player") && CurrentGumballCount < TotalGumballs)
        {
            Instantiate(Gumball);
            GumballMachineAnimator.SetTrigger("GumballAnimation");
            CurrentGumballCount++;
        }
    }


}
