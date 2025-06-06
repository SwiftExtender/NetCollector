namespace NetFighter.RequestModels
{
    public class CreatedPort
    {
        public int HostId;
        public int Number;
        public string Protocol;
        public string Info;
    }
    public class UpdatedPort
    {
        public int Id;
        public int HostId;
        public int Number;
        public string Protocol;
        public string Info;
    }
}
