using GlobalProcess.Core.Models;
using GlobalProcess.Infrastructure.Data;

public static class AppDbContextSeed
{
    public static void Seed(AppDbContext context)
    {
        if (!context.UserGroups.Any())
        {
            context.UserGroups.AddRange(
                new UserGroup
                {
                    Name = "Admin",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new UserGroup
                {
                    Name = "Manager",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new UserGroup
                {
                    Name = "User",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                }
            );

            context.SaveChanges();
        }

        if (!context.StepTypes.Any())
        {
            context.StepTypes.AddRange(
                new StepType
                {
                    Name = "Input",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new StepType
                {
                    Name = "Approval",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new StepType
                {
                    Name = "Review",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new StepType
                {
                    Name = "Notification",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new StepType
                {
                    Name = "Integration",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                },
                new StepType
                {
                    Name = "Automated",
                    CreatedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    CreatedDateTime = DateTime.Now,
                    LastModifiedByUserId = "b59ef14b-af07-497d-914d-6fd2e9e5ed7e",
                    LastModifiedDateTime = DateTime.Now
                }
            );

            context.SaveChanges();
        }
    }
}
