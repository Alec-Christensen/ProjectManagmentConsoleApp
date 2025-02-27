﻿using ProjectManagmentConsoleApp.Entities;
using ProjectManagmentConsoleApp.Factories;
using ProjectManagmentConsoleApp.Interfaces;

namespace ProjectManagmentConsoleApp.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void AddCustomer(string name)
    {
        var customer = CustomerFactory.Create(name);
        _customerRepository.AddCustomer(customer);
    }

    public List<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }

    public Customer? GetCustomerById(int id)
    {
        return _customerRepository.GetCustomerById(id);
    }
}
