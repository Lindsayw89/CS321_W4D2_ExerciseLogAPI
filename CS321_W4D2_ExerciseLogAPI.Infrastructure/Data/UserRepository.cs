using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; //added

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        //implement add
        public User Add(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }
        public User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
        public User Update(User updatedUser)
        {
            var currentUser = this.Get(updatedUser.Id);
            if (currentUser == null) return null;
            _dbContext.Entry(updatedUser).CurrentValues.SetValues(updatedUser);
            _dbContext.SaveChanges();
            return currentUser;

        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }

}
