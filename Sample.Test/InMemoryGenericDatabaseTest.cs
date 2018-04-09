using Sample.Abstraction.Models;
using Sample.Abstraction.Repositories;
using Sample.Repository;
using System;
using Xunit;

namespace Sample.Test
{
    public class InMemoryGenericDatabaseTest
    {
        [Fact]
        public void AddDatabase_And_VerifyResult_Simple()
        {
            IRepository<IUser> db = new InMemoryGenericDatabase<IUser>();
            IUser user = new User { Gender = EnumGender.Male, Name = "user1" };

            var result = db.Add(user);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.True(result.Time != null);
            Assert.True(result.Name == "user1");
        }

        [Fact]
        public void AddDatabase_And_VerifyResult_Complex()
        {
            IRepository<IUser> db = new InMemoryGenericDatabase<IUser>();
            IUser user1 = new User { Gender = EnumGender.Male, Name = "user1" };
            IUser user2 = new User { Gender = EnumGender.Male, Name = "user2" };
            IUser user3 = new User { Gender = EnumGender.Male, Name = "user3" };

            var result1 = db.Add(user1);
            var result2 = db.Add(user2);
            var result3 = db.Add(user3);
            
            Assert.False(string.IsNullOrEmpty(result1.Id));
            Assert.True(result1.Name == "user1");
            Assert.False(string.IsNullOrEmpty(result2.Id));
            Assert.True(result2.Name == "user2");
            Assert.False(string.IsNullOrEmpty(result3.Id));
            Assert.True(result3.Name == "user3");
        }

        [Fact]
        public void UpdateDatabase_And_VerifyResult()
        {
            IRepository<IUser> db = new InMemoryGenericDatabase<IUser>();
            IUser user = new User { Gender = EnumGender.Male, Name = "user1" };

            user = db.Add(user);            
            user.Gender = EnumGender.Female;
            user.Name = "mary";
            var prevId = user.Id;
            var prevTime = user.Time;
            var result = db.Update(user);

            Assert.NotNull(result);
            Assert.True(result.Id == prevId);
            Assert.True(result.Time != prevTime);            
            Assert.True(result.Name == "mary");
        }

        [Fact]
        public void DeleteDatabase_And_VerrifyResult()
        {
            IRepository<IUser> db = new InMemoryGenericDatabase<IUser>();
            IUser user1 = new User { Gender = EnumGender.Male, Name = "user1" };
            IUser user2 = new User { Gender = EnumGender.Male, Name = "user2" };

            var result1 = db.Add(user1);
            db.Add(user2);
            db.Delete(result1.Id);
            var result2 = db.GetOne(x => x.Id == result1.Id);

            Assert.Null(result2);
        }

        [Fact]
        public void GetDatabase_And_VerifyResult()
        {
            IRepository<IUser> db = new InMemoryGenericDatabase<IUser>();
            for (int i = 0; i < 10; i++)
            {
                db.Add(new User { Gender = EnumGender.Male, Name = $"user{i}" });
            }

            Assert.NotEmpty(db.GetAll());
            Assert.True(db.Count() == 10);
        }
    }
}
