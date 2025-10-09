using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using Tasks.Domain;
using Tasks.Persistense;

namespace Tasks.Tests.Common.Moq
{
    public static class DbContextMockFactory
    {
        public static Mock<ITasksDbContext> Create()
        {
            var mock = new Mock<ITasksDbContext>();

            // Users
            mock.Setup(x => x.Users).Returns(CreateDbSet<Domain.User>().Object);
            mock.Setup(x => x.Users.AddAsync(It.IsAny<Domain.User>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Domain.User user, CancellationToken _) => null!);

            // Tasks
            mock.Setup(x => x.Tasks).Returns(CreateDbSet<Domain.Task>().Object);
            mock.Setup(x => x.Tasks.AddAsync(It.IsAny<Domain.Task>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Domain.Task task, CancellationToken _) => null!);

            // SaveChangesAsync
            mock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            return mock;
        }

        private static Mock<DbSet<T>> CreateDbSet<T>() where T : class
        {
            var data = new List<T>().AsQueryable();
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            return mockSet;
        }
    }
}
