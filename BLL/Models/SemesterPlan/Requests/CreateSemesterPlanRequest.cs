namespace BLL.Models.SemesterPlan.Requests
{
    public class CreateSemesterPlanRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SemesterId { get; set; }
        public int MasterPlanId { get; set; }
    }
}
