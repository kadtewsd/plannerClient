namespace PlannerClient.Model
{
    public interface ITitleValueModel
    {
        string id { get; set; }
        string title { get; set; }

        ITitleValueModel Self { get; }
    }
}
