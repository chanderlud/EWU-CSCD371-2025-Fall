using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void Add_CompareEmployeeAndStudent_Failure()
    {
        //Arrange
        Storage storage = new ();
        Employee marge = new (new FullName("Marge", null, "Simpson"), 60000f);
        Student margeStudent = new (new FullName("Marge", null, "Simpson"), 3.0f);
        //Act
        storage.Add(marge);

        //Assert
        Assert.False(storage.Contains(margeStudent));
    }
    [Fact]
    public void Get_MaintainsName_Success()
    {
        //Arrange
        Storage storage = new ();
        Student bartStudent = new (new FullName("Bart", null, "Simpson"), 0.1f);

        //Act
        storage.Add(bartStudent);


        //Assert
        //Null override, I expect this should never be null!
        Assert.Equal(storage.Get(bartStudent.Id)!.Name, bartStudent.Name); 
    }
    [Fact]
    public void AddRemoveAdd_Student_Success()
    {
        //Arrange
        Storage storage = new ();
        Student bartStudent = new (new FullName("Bart", null, "Simpson"), 0.1f);

        //Act
        storage.Add(bartStudent);
        storage.Remove(bartStudent);
        storage.Add(bartStudent);

        //Assert
        //Null override, I expect this should never be null!
        Assert.Equal(storage.Get(bartStudent.Id)!.Name, bartStudent.Name);
    }
    [Fact]
    public void Remove_StudentFromCrowd_Success()
    {
        //Arrange
        Storage storage = new Storage();
        Student bartStudent = new (new FullName("Bart", null, "Simpson"), 0.1f);
        Student milhouseStudent = new (new FullName("Milhouse", "Van", "Houten"),4.0f);

        //Act
        storage.Add(bartStudent);
        storage.Add(milhouseStudent);
        storage.Remove(bartStudent);

        //Assert
        Assert.Null(storage.Get(bartStudent.Id));
        Assert.NotNull(storage.Get(milhouseStudent.Id));
    }
}
