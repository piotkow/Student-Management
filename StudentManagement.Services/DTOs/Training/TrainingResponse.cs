namespace StudentManagement.Services.DTOs.Training
{
    public class TrainingResponse
    {
        public int TrainingID { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Topic { get; set; }
    }
}
