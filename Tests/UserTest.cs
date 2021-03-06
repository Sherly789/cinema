using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Cinema
{
  public class UserTest : IDisposable
  {
    public UserTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=cinema_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = User.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    public void Dispose()
    {
      User.DeleteAll();
      Order.DeleteAll();
    }

    [Fact]
    public void Test2_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      User firstUser = new User("Sara");
      User secondUser = new User("Sara");

      //Assert
      Assert.Equal(firstUser, secondUser);
    }

    [Fact]
    public void Test3_Save_SavesToDatabase()
    {
      //Arrange
      User testUser = new User("Sara");

      //Act
      testUser.Save();
      List<User> result = User.GetAll();
      List<User> testList = new List<User>{testUser};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test4_Save_AssignsIdToUserObject()
    {
      //Arrange
      User testUser = new User("Sara");
      testUser.Save();

      //Act
      User savedUser = User.GetAll()[0];

      int result = savedUser.GetId();
      int testId = testUser.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test5_Find_FindsUserInDatabase()
    {
      //Arrange
      User testUser = new User("Sara");
      testUser.Save();

      //Act
      User foundUser = User.Find(testUser.GetId());

      //Assert
      Assert.Equal(testUser, foundUser);
    }

    [Fact]
    public void Test6_GetOrders_RetrievesAllOrdersWithUser()
    {
      User testUser = new User("Sara");
      testUser.Save();

      Order firstOrder = new Order(1, testUser.GetId(), 3);
      firstOrder.Save();
      Order secondOrder = new Order(2, testUser.GetId(), 4);
      secondOrder.Save();


      List<Order> testOrderList = new List<Order> {firstOrder, secondOrder};
      List<Order> resultOrderList = testUser.GetOrders();

      Assert.Equal(testOrderList, resultOrderList);
    }




  }
}
