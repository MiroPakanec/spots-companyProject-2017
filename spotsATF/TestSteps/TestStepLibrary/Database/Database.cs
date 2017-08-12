namespace spotsATF.TestSteps.TestStepLibrary.Database
{
    public class Database
    {
        public Sql.Sql Sql => new Sql.Sql();
        public Mongo.Mongo Mongo => new Mongo.Mongo();
    }
}
