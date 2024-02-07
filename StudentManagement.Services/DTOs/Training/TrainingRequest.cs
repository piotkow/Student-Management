namespace StudentManagement.Services.DTOs.Training
{
    public class TrainingRequest
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Topic { get; set; }
    }
}
