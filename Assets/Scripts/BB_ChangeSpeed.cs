using System;

public class BB_ChangeSpeed : BasketBehaviour
{
    public override void Behave(CannonController cannonContr, params string[] values) 
    {
        if (Convert.ToInt32(values[0]) == 1)
            cannonContr.velocity += Convert.ToSingle(values[1]);
        else
            cannonContr.velocity = Convert.ToSingle(values[1]);
    }
}
