namespace DapperDeneme.Dto
{
    public record WorkersDto(string WorkerName, string WorkerSurname, string WorkerFactoryName, string WorkerPositionName)
    {
        public WorkersDto() : this(default, default, default, default) { }
    }
}
