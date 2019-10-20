using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
   public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public ActivityType Add(ActivityType newActivityType)
        {
            _dbContext.ActivityTypes.Add(newActivityType);
            _dbContext.SaveChanges();
            return newActivityType;
        }
        public ActivityType Get(int id)
        {
            return _dbContext.ActivityTypes.FirstOrDefault(a => a.Id == id);
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            var currentActivityType = this.Get(updatedActivityType.Id);
            if (currentActivityType == null) return null;
            _dbContext.Entry(updatedActivityType).CurrentValues.SetValues(updatedActivityType);
            _dbContext.SaveChanges();
            return currentActivityType;
        }
        public IEnumerable<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes.ToList();
        }
        public void Remove(ActivityType activityType)
        {
            _dbContext.ActivityTypes.Remove(activityType);
            _dbContext.SaveChanges();
        }
    }
}
