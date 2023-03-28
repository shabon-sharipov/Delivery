using Delivery.Domain.Abstract;

public  class Person : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DataOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
