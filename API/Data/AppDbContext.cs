﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain;
using Employee = Domain.Employee;

public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet< User> Users { get; set; } = default!;

        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
}
