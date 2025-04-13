using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsDone).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.DueDate).IsRequired(false);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.TodoItems)
                .HasForeignKey(x => x.TodoCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
               new TodoItem
               {
                   Id = 1,
                   Title = "First Todo",
                   IsDone = false,
                   DueDate = DateTime.Now.AddDays(1),
                   Note = "This is the first todo",
                   TodoCategoryId = 1,
                   CreateDate = DateTime.Now,
                   UpdateDate = DateTime.Now
               },
               new TodoItem
               {
                   Id = 2,
                   Title = "Second Todo",
                   IsDone = false,
                   DueDate = DateTime.Now.AddDays(2),
                   Note = "This is the second todo",
                   TodoCategoryId = 2,
                   CreateDate = DateTime.Now,
                   UpdateDate = DateTime.Now
               },
               new TodoItem
               {
                   Id = 3,
                   Title = "Third Todo",
                   IsDone = false,
                   DueDate = DateTime.Now.AddDays(3),
                   Note = "This is the third todo",
                   TodoCategoryId = 3,
                   CreateDate = DateTime.Now,
                   UpdateDate = DateTime.Now
               },

               new TodoItem
               {
                   Id = 4,
                   Title = "Fourth Todo",
                   IsDone = false,
                   DueDate = DateTime.Now.AddDays(4),
                   Note = "This is the fourth todo",
                   TodoCategoryId = 4,
                   CreateDate = DateTime.Now,
                   UpdateDate = DateTime.Now

               }
               );

        }
    }
}
