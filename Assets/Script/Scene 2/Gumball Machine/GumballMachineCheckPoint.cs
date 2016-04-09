using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GumballMachineCheckPoint : MonoBehaviour {

    public int TotalGumballs;
    public GameObject GumballPrefab;
    private int CurrentGumballCount = 0;
    public Animator GumballMachineAnimator;

    void OnTriggerEnter(Collider Object)
    {
        if (Object.tag.Equals("Player") && CurrentGumballCount < TotalGumballs)
        {
            GameObject obj = Instantiate(GumballPrefab);
            obj.GetComponent<SpawnOnCreate>().createdObject.GetComponent<MeshRenderer>().material = myInventory.GetGumball().color;
            GumballMachineAnimator.SetTrigger("GumballAnimation");
            CurrentGumballCount++;
        }
    }

    public Inventory myInventory;

    // Called once when script is loaded, before start function is called

    //Tells Unity that this class can be serialized and thus can be saved. Serialization is converting an object into something that can be written to disc. Deserialization is the reverse of that.
    [System.Serializable]
    public class Inventory
    {
        //Storing a list of posible gumballs. Added this list in Unity using the Inspector.
        public List<Gumball> Gumballs;

        public Inventory(List<Gumball> paints)
        {
            Gumballs = paints;
        }

        public Gumball GetGumball()
        {
            //Organises Gumballs in descending order via the list count. Goes from highest to lowest gumball count. A delegate is a type that represents references to methods with a particular parameter list and return type
            Gumballs.Sort(delegate (Gumball x, Gumball y)
            {
                return y.count.CompareTo(x.count);
            });

            //This iterates over the entire list of gumballs that are defined in Unity.
            foreach (Gumball pbp in Gumballs)
            {

                // This calls get gumball on the gumball object.
                Gumball pb = pbp.GetGumball();
                if (pb != null)
                {
                    return pb;
                }
            }
            // No Gumballs left
            return null;
        }
    }

    //Stored the material which has the colour and the number of posible gumballs.
    [System.Serializable]
    public class Gumball
    {
        public Material color;
        public int count;

        public object Total { get; internal set; }

        //This checks if it has more than 0 gumballs, if so decrease the number of gumballs and return itself. Else return nothing (null).
        public Gumball GetGumball()
        {
            if (count > 0)
            {
                count--;
                return this;
            }
            else {
                return null;
            }
        }
    }
}
