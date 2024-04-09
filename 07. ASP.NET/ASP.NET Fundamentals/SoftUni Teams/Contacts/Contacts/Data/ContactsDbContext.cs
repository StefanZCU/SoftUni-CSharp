using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data;

public class ContactsDbContext : IdentityDbContext
{
    public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<ApplicationUserContact>()
            .HasKey(auc => new { auc.ApplicationUserId, auc.ContactId });
        
        base.OnModelCreating(builder);
    }
}