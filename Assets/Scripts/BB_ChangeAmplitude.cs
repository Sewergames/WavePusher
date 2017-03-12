using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_ChangeAmplitude : BasketBehaviour
{
    public override void Behave(CannonController cannonContr, params string[] values)
    {
        if (Convert.ToInt32(values[0]) == 1)
            cannonContr.amplitude += Convert.ToSingle(values[1]);
        else
            cannonContr.amplitude = Convert.ToSingle(values[1]);
    }
}
