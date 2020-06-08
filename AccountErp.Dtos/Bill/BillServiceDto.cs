namespace AccountErp.Dtos.Bill
{
    public class BillServiceDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
