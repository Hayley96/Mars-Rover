using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRoverTests
{
    public class HelpersTests
    {
        private List<string> ListTest;
        [SetUp]
        public void Setup()
        {
           ListTest = new List<string>();
        }

        [Test]
        public void AddItemToList_Should_Populate_A_Given_List_With_Supplied_Parameters()
        {
            ListTest = new List<string>();
            AddItemToList.Add(ListTest, "Hello");
            Assert.IsTrue(ListTest.Count > 0);
        }

        [Test]
        public void AddItemToList_Should_Have_Count_5_When_Executed_5_Times()
        {
            ListTest = new List<string>();
            for(int i = 0; i < 5; i++)
                AddItemToList.Add(ListTest, "Hello");
            Assert.IsTrue(ListTest.Count == 5);
        }
    }
}