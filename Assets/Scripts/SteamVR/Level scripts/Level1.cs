public class Level1 : LevelTeleportPoint
{
    public Level1()
    {
        // Set the title, the original title is just a format
        title = string.Format(title, 1);

        //onTeleport = new System.Action(() => DealWithTeleport());
    }

    public override void DealWithTeleport()
    {
        throw new System.NotImplementedException();
    }
}
