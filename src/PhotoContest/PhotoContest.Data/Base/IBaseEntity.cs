namespace PhotoContest.Data.Base
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}
