public class MapsController
{
    public void BonusLapExecuted()
    {
        foreach (Gun gun in World.Instance.GunsController.GetGuns())
        {
            gun.GunMovement.UpdateLaps(World.Instance.BonusManager.GetBonus(2).CurrentLevel);
        }
    }
}
