using System;
using Kozlovskiy.TaskPlanner.Domain.Models;

namespace Kozlovskiy.TaskPlanner.DataAccess.Abstractions
{
    public interface IWorkItemsRepository
    {
        
        Guid Add(WorkItem workItem);

        WorkItem Get(Guid id);

        WorkItem[] GetAll();

        bool Update(WorkItem workItem);

        bool Remove(Guid id);

        void SaveChanges();
    }
}