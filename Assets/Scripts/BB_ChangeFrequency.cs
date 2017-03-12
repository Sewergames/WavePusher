using System;

public class BB_ChangeFrequency : BasketBehaviour
{
    public override void Behave(CannonController cannonContr, params string[] values)
    {
        if (Convert.ToInt32(values[0]) == 1)
            cannonContr.frequency += Convert.ToSingle(values[1]);
        else
            cannonContr.frequency = Convert.ToSingle(values[1]);
    }
}
