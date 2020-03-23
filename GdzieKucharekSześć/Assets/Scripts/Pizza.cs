using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : Item
{
    public bool  pineapple, sausage, cheese, tomatoe, mushroom, mozzarrella, spices,isBaken, isOverisBaken, isPrepared;

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        ((Item)this).Start();

        isPrepared = false;
        pineapple = false;
        sausage = false;
        cheese = false;
        tomatoe = false;
        mushroom = false;
        mozzarrella = false;
        spices = false;
        isBaken = false;
        isOverisBaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
