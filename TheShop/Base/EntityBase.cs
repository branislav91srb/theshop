namespace TheShop.Base
{
    public abstract class EntityBase
    {
        public int ID { get; set; }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
