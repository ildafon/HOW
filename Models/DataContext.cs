using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoustonOnWire.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }


        public DbSet<Channel> Channels { get; set; }

        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<ChannelCustomer> ChannelCustomers { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Avatar> Avatars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChannelCustomer>()
                .HasKey(t => new { t.ChannelId, t.CustomerId });

            modelBuilder.Entity<ChannelCustomer>()
                .HasOne(cc => cc.Channel)
                .WithMany(c => c.ChannelCustomers)
                .HasForeignKey(cc => cc.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChannelCustomer>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.ChannelCustomers)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Avatar)
                .WithOne(a => a.Customer)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Visitor>()
                .HasOne(c => c.Avatar)
                .WithOne(a => a.Visitor)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Chat>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(c => c.Chats)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chat>()
                .HasOne<Visitor>(c => c.Visitor)
                .WithOne(c => c.Chat)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Message>()
                .HasOne<Chat>(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .Property<DateTime>(m => m.Received)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
                



            modelBuilder.Entity<Channel>().HasData(
                new Channel { ChannelId = 1, Name = "Test1" },
                new Channel { ChannelId = 2, Name = "Test2" },
                new Channel { ChannelId = 3, Name = "Test3" },
                new Channel { ChannelId = 4, Name = "Test4" },
                new Channel { ChannelId = 5, Name = "Test5" },
                new Channel { ChannelId = 6, Name = "Test6" },
                new Channel { ChannelId = 7, Name = "Test7" },
                new Channel { ChannelId = 8, Name = "Test8" },
                new Channel { ChannelId = 9, Name = "Test9" },
                new Channel { ChannelId = 10, Name = "Test10" },
                new Channel { ChannelId = 11, Name = "Test11" },
                new Channel { ChannelId = 12, Name = "Test12" },
                new Channel { ChannelId = 13, Name = "Test13" },
                new Channel { ChannelId = 14, Name = "Test14" },
                new Channel { ChannelId = 15, Name = "Test15" },
                new Channel { ChannelId = 16, Name = "Test16" },
                new Channel { ChannelId = 17, Name = "Test17" },
                new Channel { ChannelId = 18, Name = "Test18" },
                new Channel { ChannelId = 19, Name = "Test19" },
                new Channel { ChannelId = 20, Name = "Test20" },
                new Channel { ChannelId = 21, Name = "Test21" },
                new Channel { ChannelId = 22, Name = "Test22" },
                new Channel { ChannelId = 23, Name = "Test23" },
                new Channel { ChannelId = 24, Name = "Test24" },
                new Channel { ChannelId = 25, Name = "Test25" },
                new Channel { ChannelId = 26, Name = "Test26" },
                new Channel { ChannelId = 27, Name = "Test27" },
                new Channel { ChannelId = 28, Name = "Test28" },
                new Channel { ChannelId = 29, Name = "Test29" },
                new Channel { ChannelId = 30, Name = "Test30" },
                new Channel { ChannelId = 31, Name = "Test31" },
                new Channel { ChannelId = 32, Name = "Test32" },
                new Channel { ChannelId = 33, Name = "Test33" },
                new Channel { ChannelId = 34, Name = "Test34" },
                new Channel { ChannelId = 35, Name = "Test35" },
                new Channel { ChannelId = 36, Name = "Test36" },
                new Channel { ChannelId = 37, Name = "Test37" },
                new Channel { ChannelId = 38, Name = "Test38" },
                new Channel { ChannelId = 39, Name = "Test39" },
                new Channel { ChannelId = 40, Name = "Test40" },
                new Channel { ChannelId = 41, Name = "Test41" },
                new Channel { ChannelId = 42, Name = "Test42" },
                new Channel { ChannelId = 43, Name = "Test43" },
                new Channel { ChannelId = 44, Name = "Test44" },
                new Channel { ChannelId = 45, Name = "Test45" },
                new Channel { ChannelId = 46, Name = "Test46" },
                new Channel { ChannelId = 47, Name = "Test47" },
                new Channel { ChannelId = 48, Name = "Test48" },
                new Channel { ChannelId = 49, Name = "Test49" },
                new Channel { ChannelId = 50, Name = "Test50" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "Operator1",
                    Email = "operator1@example.com",
                    AvatarId = 1
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Operator2",
                    Email = "operator2@example.com",
                    AvatarId = 2
                }
            );

            modelBuilder.Entity<ChannelCustomer>().HasData(
                new ChannelCustomer { ChannelId = 1, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 1, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 2, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 2, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 3, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 3, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 4, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 4, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 5, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 5, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 6, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 6, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 7, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 7, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 8, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 8, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 9, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 9, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 10, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 10, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 11, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 11, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 12, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 12, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 13, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 13, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 14, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 14, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 15, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 15, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 16, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 16, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 17, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 17, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 18, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 18, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 19, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 19, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 20, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 20, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 21, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 21, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 22, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 22, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 23, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 23, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 24, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 24, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 25, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 25, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 26, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 26, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 27, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 27, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 28, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 28, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 29, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 29, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 30, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 30, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 31, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 31, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 32, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 32, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 33, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 33, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 34, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 34, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 35, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 35, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 36, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 36, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 37, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 37, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 38, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 38, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 39, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 39, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 40, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 40, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 41, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 41, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 42, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 42, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 43, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 43, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 44, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 44, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 45, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 45, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 46, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 46, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 47, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 47, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 48, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 48, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 49, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 49, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 50, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 50, CustomerId = 2 }
               

            );

            modelBuilder.Entity<Avatar>().HasData(
                new Avatar
                {
                    AvatarId = 1,
                    Url = "/assets/av-1.png"
                },
                new Avatar
                {
                    AvatarId = 2,
                    Url = "/assets/av-2.png"
                },
                new Avatar
                {
                    AvatarId = 3,
                    Url = "/assets/av-3.png"
                },
                new Avatar
                {
                    AvatarId = 4,
                    Url = "/assets/av-4.png"
                }
            );


            modelBuilder.Entity<Visitor>().HasData(
                new Visitor
                {
                    VisitorId = 1,
                    Name = "Visitor1",
                    Email = "visitor1@example.com",
                    Phone = "+79190000001",
                    Comment = "Comment1",
                    AvatarId = 3
                },
                new Visitor
                {
                    VisitorId = 2,
                    Name = "Visitor2",
                    Email = "visitor2@example.com",
                    Phone = "+79190000002",
                    Comment = "Comment2",
                    AvatarId = 4
                }
            );

            modelBuilder.Entity<Chat>().HasData(
                new Chat
                {
                    ChatId = 1,
                    IsActive = true,
                    Score = 10,

                    CustomerId = 1,
                    VisitorId = 1,
                    LastMessageId = 2
                },
                new Chat
                {
                    ChatId = 2,
                    IsActive = true,
                    Score = 5,

                    CustomerId = 1,
                    VisitorId = 2,
                    LastMessageId = 4
                }
                
            );

            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageId = 1,
                    Content = "Hello",
                    FromVisitor = true,
                    ChatId = 1
                    
                },
                new Message
                {
                    MessageId = 2,
                    Content = "Hello",
                    FromVisitor = false,
                    ChatId = 1
                },
                new Message
                {
                    MessageId = 3,
                    Content = "Hello",
                    FromVisitor = true,
                    ChatId = 2
                },
                new Message
                {
                    MessageId = 4,
                    Content = "Hello",
                    FromVisitor = false,
                    ChatId = 2
                }
                
            );



        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("Received").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
