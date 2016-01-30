using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemArray;
    public int[] chanceArray;
    public int chanceToSpawnNothing;

    private void Start ()
    {
        //roll to spawn nothing
        if (Random.Range(0, 100) < chanceToSpawnNothing)
            return;

        //roll for which item to spawn
        int itemSelection = (int)Random.Range(0,100);
        int chanceSummation = 0;
        int index = -1;
        do
        {
            index++;
            chanceSummation += chanceArray[index];
        } while (chanceSummation < itemSelection);

        if (index >= itemArray.Length)
            index = itemArray.Length - 1;

        GameObject selectedItem = itemArray[index];

        //spawn the selected item and make this object its parent
       GameObject item = Instantiate(selectedItem, transform.position, Quaternion.identity) as GameObject;
       item.transform.parent = transform;
	}  
}
