using NUnit.Framework;

namespace No1.Solution.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void TestDefaultValidator()
        {
            IRepository repository = new SqlRepository();
            var pcs = new PasswordCheckerService(repository);

            Assert.That(pcs.VerifyPassword("pa55word").Item2, Is.EqualTo("Password is Ok. User was created"));
            Assert.That(pcs.VerifyPassword(string.Empty).Item2, Is.EqualTo("password is empty"));
            Assert.That(pcs.VerifyPassword("a1").Item2, Is.EqualTo("a1 length too short"));
            Assert.That(pcs.VerifyPassword("abcdef012345").Item2, Is.EqualTo("abcdef012345 length too long"));
            Assert.That(pcs.VerifyPassword("abcdefgh").Item2, Is.EqualTo("abcdefgh hasn't digits"));
            Assert.That(pcs.VerifyPassword("01234567").Item2, Is.EqualTo("01234567 hasn't alphanumerical chars"));
        }

        [Test]
        public void TestCustomValidator()
        {
            IRepository repository = new SqlRepository();
            var pcs = new PasswordCheckerService(repository);
            
            Assert.That(pcs.VerifyPassword("pa55word", CustomValidator.Validate).Item2, Is.EqualTo("Password is Ok. User was created"));
            Assert.That(pcs.VerifyPassword(string.Empty, CustomValidator.Validate).Item2, Is.EqualTo("password is empty"));
            Assert.That(pcs.VerifyPassword("a1", CustomValidator.Validate).Item2, Is.EqualTo("a1 length too short"));
            Assert.That(pcs.VerifyPassword("abcdefgh0123456", CustomValidator.Validate).Item2, Is.EqualTo("abcdefgh0123456 length too long"));
            Assert.That(pcs.VerifyPassword("admin0", CustomValidator.Validate).Item2, Is.EqualTo("admin0 can't contain admin word"));
            Assert.That(pcs.VerifyPassword("abc123!", CustomValidator.Validate).Item2, Is.EqualTo("abc123! contains unavailable symbols"));
        }
    }
}
