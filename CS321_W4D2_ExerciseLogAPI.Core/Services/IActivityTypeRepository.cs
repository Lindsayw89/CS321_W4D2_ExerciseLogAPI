using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityTypeRepository
    {
        // create
        ActivityType Add(ActivityType newActivityType);
        // read
        ActivityType Get(int id);
        // update
        ActivityType Update(ActivityType activityType);
        // delete
        void Remove(ActivityType activityType);
        // list
        IEnumerable<ActivityType> GetAll();
    }
}
