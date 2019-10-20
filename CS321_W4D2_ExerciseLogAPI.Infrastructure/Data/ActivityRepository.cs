using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _dbContext;
        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity newActivity)
        {
            _dbContext.Activity.Add(newActivity);
            _dbContext.SaveChanges();
            return newActivity;
        }
        public Activity Get(int id)
        {

            return _dbContext.Activity
                .Include(a=>a.user)
                .Include(a=> a.activityType)
                .FirstOrDefault(a => a.Id == id);  
        }
        public Activity Update(Activity updatedActivity)
        {
            var currentActivity = this.Get(updatedActivity.Id);
            if (currentActivity == null) return null;
            _dbContext.Entry(updatedActivity).CurrentValues.SetValues(updatedActivity);
            _dbContext.SaveChanges();
            return currentActivity;
        }
        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activity.ToList();
        }
        public void Remove(Activity activity)
        {
            _dbContext.Activity.Remove(activity);
            _dbContext.SaveChanges();
        }

    }
}
