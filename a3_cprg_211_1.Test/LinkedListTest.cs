namespace a3_cprg211_1.Test
{
    using a3_cprg211_1.Problem_Domain;
    using a3_cprg211_1.Utility;
    using NUnit.Framework;

    [TestFixture]
    public class LinkedListTest
    {
        private ILinkedListADT users;

        [SetUp]
        public void Setup()
        {
            users = new SLL();
        }

        [Test]
        public void LinkedList_IsEmpty()
        {
            Assert.IsTrue(users.IsEmpty());
        }

        [Test]
        public void AddFirst_AddsElement()
        {
            users.AddFirst(new User(1, "Test User 1", "testuser1@example.com", "pass123"));
            Assert.IsFalse(users.IsEmpty());
        }

        [Test]
        public void AddLast_AddsElement()
        {
            var lastUser = new User(2, "Test User 2", "testuser2@example.com", "pass456");
            users.AddLast(lastUser);
            Assert.AreEqual(lastUser, users.GetValue(users.Count() - 1));
        }

        [Test]
        public void Add_InsertsElementAtIndex()
        {
            users.AddLast(new User(1, "Existing User", "existing@example.com", "password123"));

            var newUser = new User(3, "Test User 3", "testuser3@example.com", "pass789");
            users.Add(newUser, 1);

            Assert.AreEqual(newUser, users.GetValue(1));
        }

        [Test]
        public void Replace_ReplacesElementAtIndex()
        {
            users.AddLast(new User(1, "Initial User", "initial@example.com", "initialPass"));

            var newUser = new User(4, "New User", "newuser@example.com", "newpass");
            users.Replace(newUser, 0);

            User replacedUser = users.GetValue(0);
            Assert.IsNotNull(replacedUser);
            Assert.AreEqual(newUser.Name, replacedUser.Name);
            Assert.AreEqual(newUser.Email, replacedUser.Email);
            Assert.AreEqual(newUser.Password, replacedUser.Password);
        }

        [Test]
        public void RemoveFirst_RemovesElementFromBeginning()
        {
            users.AddFirst(new User(5, "To Remove", "remove@example.com", "pass123"));
            int initialCount = users.Count();
            users.RemoveFirst();
            Assert.AreEqual(initialCount - 1, users.Count());
        }

        [Test]
        public void RemoveLast_RemovesElementFromEnd()
        {
            users.AddLast(new User(6, "Last User", "lastuser@example.com", "lastpass"));
            int initialCount = users.Count();
            users.RemoveLast();
            Assert.AreEqual(initialCount - 1, users.Count());
        }

        [Test]
        public void Remove_RemovesElementAtIndex()
        {
            users.AddFirst(new User(7, "First for Removal", "firstremove@example.com", "passrem1"));
            users.AddLast(new User(8, "Last for Removal", "lastremove@example.com", "passrem2"));
            int initialCount = users.Count();
            users.Remove(0);
            Assert.AreEqual(initialCount - 1, users.Count());
        }

        [Test]
        public void GetValue_RetrievesElementAtIndex()
        {
            var user = new User(9, "Test User 4", "testuser4@example.com", "pass101112");
            users.AddLast(user);
            Assert.AreEqual(user, users.GetValue(users.Count() - 1));
        }

        [Test]
        public void Contains_SearchesForElement()
        {
            var user = new User(10, "Test User 5", "testuser5@example.com", "pass131415");
            users.AddLast(user);
            Assert.IsTrue(users.Contains(user));
        }

        [Test]
        public void ReverseLinkedList_ReversesList()
        {
            SLL users = new SLL();

            users.AddLast(new User(1, "User 1", "email1@example.com", "password1"));
            users.AddLast(new User(2, "User 2", "email2@example.com", "password2"));
            users.AddLast(new User(3, "User 3", "email3@example.com", "password3"));

            users.Head = users.ReverseLinkedList(users.Head);

            Assert.AreEqual("User 3", users.GetValue(0).Name);
            Assert.AreEqual("User 2", users.GetValue(1).Name);
            Assert.AreEqual("User 1", users.GetValue(2).Name);
        }


    }
}
