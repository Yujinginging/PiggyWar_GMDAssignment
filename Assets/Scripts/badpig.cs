using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badpig : HeatObject
{
    public override void BadPigDead()
    {

        Manager._instance.badPigs.Remove(this);

    }
}
