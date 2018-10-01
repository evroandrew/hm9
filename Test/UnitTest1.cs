using System;
using Collections.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private MyList<int> MyListInit()
        {
            MyList<int> list = new MyList<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            return list;
        }
        [TestMethod]
        public void MyListCtorTestMethod()
        {
            MyList<int> list = new MyList<int>();
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(false, list.IsReadOnly);

            MyList<string> listA = new MyList<string>();
            Assert.IsNotNull(listA);
            Assert.AreEqual(0, listA.Count);
            Assert.AreEqual(false, listA.IsReadOnly);
        }
        [TestMethod]
        public void MyListAddTestMethod()
        {
            MyList<int> list = new MyList<int>();
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
            list.Add(10);
            Assert.AreEqual(1, list.Count);
            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }
            Assert.AreEqual(10001, list.Count);
        }
        [TestMethod]
        public void MyListItemTestMethod_Set()
        {
            MyList<int> list = MyListInit();
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], list[i]);
            }
        }
        [TestMethod]
        public void MyListItemTestMethod_Get()
        {
            MyList<int> list = MyListInit();
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], list[i]);
            }
            list[0] = 100;
            Assert.AreEqual(list[0], 100);
            list[9] = 100;
            Assert.AreEqual(list[9], 100);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTestMethod_GetException_1()
        {
            MyList<int> list = new MyList<int>();
            Assert.AreEqual(list[0], 1);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTestMethod_GetException_2()
        {
            MyList<int> list = new MyList<int>();
            Assert.AreEqual(list[-1], 1);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTestMethod_GetException_3()
        {
            MyList<int> list = new MyList<int>();
            list[-1] = 100;
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListItemTestMethod_GetException_4()
        {
            MyList<int> list = new MyList<int>();
            list[1] = 100;
        }
        [TestMethod]
        public void MyListClearTestMethod()
        {
            MyList<int> list = MyListInit();
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], list[i]);
            }
            Assert.AreEqual(arr.Length, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void MyListContainsTestMethod_1()
        {
            MyList<int> list = MyListInit();
            Assert.AreEqual(true, list.Contains(1));
            Assert.AreEqual(true, list.Contains(5));
            Assert.AreEqual(true, list.Contains(10));
        }
        [TestMethod]
        public void MyListContainsTestMethod_2()
        {
            MyList<int> list = MyListInit();
            Assert.AreEqual(false, list.Contains(-1));
            Assert.AreEqual(false, list.Contains(100));
            Assert.AreEqual(false, list.Contains(Int32.MaxValue));
            Assert.AreEqual(false, list.Contains(Int32.MaxValue));
        }
        [TestMethod]
        public void MyListCopyToTestMethod()
        {
            MyList<int> list = MyListInit();
            int[] arr2 = new int[list.Count];
            list.CopyTo(arr2, 0);
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(arr2[i], list[i]);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListCopyToTestMethod_1()
        {
            MyList<int> list = MyListInit();
            int[] arr1 = new int[4];
            list.CopyTo(arr1, 0);
        }
        [TestMethod]
        public void MyListIndexOfTestMethod()
        {
            MyList<int> list = MyListInit();
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(9, list.IndexOf(10));
            Assert.AreEqual(-1, list.IndexOf(100));
        }
        [TestMethod]
        public void MyListInsertTestMethod()
        {
            MyList<int> list = MyListInit();
            list.Insert(4, 2);
            int[] arr1 = { 1, 2, 3, 4, 2, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr1[i], list[i]);
            }
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(10, list.IndexOf(10));
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MyListInsertTestMethod_1()
        {
            MyList<int> list = new MyList<int>();
            list.Insert(4, 2);
            list.Insert(-1, 2);
            list.Insert(40, 2);
        }
        [TestMethod]
        public void MyListInsertTestMethod_2()
        {
            MyList<int> list = new MyList<int>();
            list.Insert(0, 2);
            Assert.AreEqual(2, list[0]);
        }
        [TestMethod]
        public void MyListRemoveTestMethod()
        {
            MyList<int> list = MyListInit();
            Assert.AreEqual(list.Remove(1), true);
            int[] arr1 = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr1.Length; i++)
            {
                Assert.AreEqual(arr1[i], list[i]);
            }
            Assert.AreEqual(list.Remove(5), true);
            int[] arr2 = { 2, 3, 4, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr2.Length; i++)
            {
                Assert.AreEqual(arr2[i], list[i]);
            }
            Assert.AreEqual(list.Remove(100), false);
            for (int i = 0; i < arr2.Length; i++)
            {
                Assert.AreEqual(arr2[i], list[i]);
            }
        }
        [TestMethod]
        public void MyListRemoveAtTestMethod()
        {
            MyList<int> list = MyListInit();
            list.RemoveAt(0);
            int[] arr1 = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr1.Length; i++)
            {
                Assert.AreEqual(arr1[i], list[i]);
            }
            list.RemoveAt(3);
            int[] arr2 = { 2, 3, 4, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr2.Length; i++)
            {
                Assert.AreEqual(arr2[i], list[i]);
            }
            list.RemoveAt(-1);
            list.RemoveAt(100);
            for (int i = 0; i < arr2.Length; i++)
            {
                Assert.AreEqual(arr2[i], list[i]);
            }
        }
        [TestMethod]
        public void MyListIEnumerableTestMethod()
        {
            MyList<int> list = MyListInit();
            int i = 0;
            foreach (int p in list)
            {
                Assert.AreEqual(arr[i++], p);
            }
        }
    }
}
