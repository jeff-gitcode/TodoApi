namespace Domain.ValueObjects
{
    public class TodoStatus
    {
        public static readonly TodoStatus Pending = new TodoStatus("Pending");
        public static readonly TodoStatus Completed = new TodoStatus("Completed");
        public static readonly TodoStatus InProgress = new TodoStatus("In Progress");

        public string Value { get; }

        private TodoStatus(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;

        public static implicit operator string(TodoStatus status) => status.Value;

        public static explicit operator TodoStatus(string value)
        {
            return value switch
            {
                "Pending" => Pending,
                "Completed" => Completed,
                "In Progress" => InProgress,
                _ => throw new ArgumentException("Invalid TodoStatus value")
            };
        }
    }
}