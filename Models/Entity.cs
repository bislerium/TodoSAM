using SQLite;

namespace TodoSAM.Models
{
    public abstract class Entity<T> where T : IEquatable<T>
    {
        [PrimaryKey]
        public T Id { get; set; }
    }
}
