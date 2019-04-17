using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedLists_Test
{
    [TestClass]
    public class LinkedListTest
    {
        LinkedList<string> ls = new LinkedList<string>();
        
        [TestMethod]
        public void Empty_on_constructor()
        {
            LinkedList<int> ls = new LinkedList<int>();
            Assert.AreEqual(0, ls.Count);
            //Assert.AreEqual(null, ls._firstNode);
        }

        [TestMethod]
        public void GetNode_on_empty_list()
        {
            var node = ls.GetNode(ls.Count);
            Assert.AreEqual(null, node);
        }
        
        [TestMethod]
        public void GetNode_out_of_range_exception()
        {
            var node = ls.GetNode(9);
            Assert.AreEqual(null, node);
        }

        [TestMethod]
        public void GetNode_on_last_node()
        {
            ls.Add("testNode1");
            var node = ls.GetNode(ls.Count-1);
            Assert.AreEqual("testNode1", node.Element);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetNode_out_of_range_negative()
        {
            var node = ls.GetNode(-19);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_from_empty_list_send_error()
        {
            LinkedList<string> ls = new LinkedList<string>();
            ls.Get(1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_from_out_of_range_send_error()
        {
            LinkedList<string> ls = new LinkedList<string>();
            ls.Get(1);
        }
        
        [TestMethod]
        public void Add_element_increment_Count()
        {
            ls.Add("test1");
            Assert.AreEqual(1, ls.Count);
            ls.Add("test2");
            Assert.AreEqual(2, ls.Count);
            ls.Add("test3");
            Assert.AreEqual(3, ls.Count);
            ls.Add("test4");
            Assert.AreEqual(4, ls.Count);
        }

        [TestMethod]
        public void Add_to_list_and_Get_correct_object()
        {
            ls.Add("test1");
            Assert.AreEqual("test1", ls.Get(0));
            ls.Add("test2");
            Assert.AreEqual("test2", ls.Get(1));
            ls.Add("test3");
            Assert.AreEqual("test3", ls.Get(2));
            ls.Add("test4");
            Assert.AreEqual("test4", ls.Get(3));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_out_of_max_send_error()
        {
            ls.Insert("testInsert", 1);
        }

        [TestMethod]
        public void Insert_on_max_increment_Count()
        {
            ls.Insert("test1", ls.Count);
            Assert.AreEqual(1, ls.Count);
            ls.Insert("test2", ls.Count);
            Assert.AreEqual(2, ls.Count);
            ls.Insert("test3", ls.Count);
            Assert.AreEqual(3, ls.Count);
            ls.Insert("test4", ls.Count);
            Assert.AreEqual(4, ls.Count);
        }

        [TestMethod]
        public void Insert_in_between_increment_Count()
        {
            ls.Add("test1");
            ls.Add("test2");
            ls.Add("test3");
            ls.Add("test4");
            ls.Add("test5");

            ls.Insert("testInsert", 3);
          
           Assert.AreEqual(6, ls.Count);
        }

        [TestMethod]
        public void Insert_in_between_moves_correctly_objects()
        {
            ls.Add("test1");
            ls.Add("test2");
            ls.Add("test3");
            ls.Add("test4");
            ls.Add("test5");

            ls.Insert("testInsert", 3);
            Assert.AreEqual("testInsert", ls.Get(3));
        }

        [TestMethod]       
        public void Remove_decrements_Count()
        {
            string testRemove = "testRemove";
            ls.Add(testRemove);
            int count = ls.Count;
            ls.Remove(testRemove);
            Assert.AreEqual(ls.Count, count-1);            
        }

        [TestMethod]
        public void Remove_in_between_moves_next_element()
        {
            ls.Add("test1");
            ls.Add("test2");
            ls.Add("test3");
            ls.Add("test4");
            ls.Add("test5");

            ls.Remove("test3");
            Assert.AreEqual("test4", ls.Get(2));
        }
    }
}
