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
                new Channel { ChannelId = 2, Name = "Test2" }    
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
                }, new Customer
                {
                    CustomerId = 3,
                    Name = "Operator3",
                    Email = "operator3@example.com",
                    AvatarId = 5
                },
                new Customer
                {
                    CustomerId = 4,
                    Name = "Operator4",
                    Email = "operator4@example.com",
                    AvatarId = 6
                }
            );

            modelBuilder.Entity<ChannelCustomer>().HasData(
                new ChannelCustomer { ChannelId = 1, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 1, CustomerId = 2 },
                new ChannelCustomer { ChannelId = 2, CustomerId = 1 },
                new ChannelCustomer { ChannelId = 2, CustomerId = 2 }             
                               

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
                },
                new Avatar
                {
                    AvatarId = 5,
                    Url = "/assets/av-5.png"
                },
                new Avatar
                {
                    AvatarId = 6,
                    Url = "/assets/av-6.png"
                },
                new Avatar
                {
                    AvatarId = 7,
                    Url = "/assets/av-7.png"
                },
                new Avatar
                {
                    AvatarId = 8,
                    Url = "/assets/av-8.png"
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
                    Content = "What is Lorem Ipsum?",
                    FromVisitor = true,
                    ChatId = 1
                    
                },
                new Message
                {
                    MessageId = 2,
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
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
                },
                new Message
                {
                    MessageId = 5,
                    Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    FromVisitor = true,
                    ChatId = 1

                },
                new Message
                {
                    MessageId = 6,
                    Content = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    FromVisitor = false,
                    ChatId = 1
                },
                new Message
                {
                    MessageId = 7,
                    Content = "Where does it come from?",
                    FromVisitor = true,
                    ChatId = 1

                },
                new Message
                {
                    MessageId = 8,
                    Content = "software like Aldus PageMaker including versions of Lorem Ipsum.",
                    FromVisitor = false,
                    ChatId = 1
                },
                new Message
                {
                    MessageId = 9,
                    Content = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    FromVisitor = true,
                    ChatId = 1

                },
                new Message
                {
                    MessageId = 10,
                    Content = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    FromVisitor = false,
                    ChatId = 1
                },
                new Message
                {
                    MessageId = 11,
                    Content = "Where does it come from?",
                    FromVisitor = true,
                    ChatId = 1

                },
                new Message
                {
                    MessageId = 12,
                    Content = "software like Aldus PageMaker including versions of Lorem Ipsum.",
                    FromVisitor = false,
                    ChatId = 1
                }



            );



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
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
