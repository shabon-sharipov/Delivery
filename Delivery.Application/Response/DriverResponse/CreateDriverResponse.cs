﻿using Delivery.Application.Respons;
using Delivery.Application.Response.SenderResponse;

public class CreateDriverResponse : DriverResponse
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}