using System;
using System.Security.Cryptography;
using Xunit;

namespace GradeBook.Tests
{
    //define delegate
    public delegate string WriteLogDelegate(string logMessage);
    
    public class TypeTests
    {
        int count = 0;
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            
            var result = log("Hello");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            int x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "liz";
            var upper = MakeUppercase(name);
            
            Assert.Equal("liz", name);
            Assert.Equal("LIZ", upper);
        }

        private string MakeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }
        
        private void SetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook.Name = name;
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
