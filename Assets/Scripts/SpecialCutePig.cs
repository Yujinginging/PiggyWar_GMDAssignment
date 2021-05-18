using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCutePig : cutepig
{
   public override void ShowSpeedUpSkill()
    {
        base.ShowSpeedUpSkill();
        rigidBody2D.velocity *= 2;
    }
}
