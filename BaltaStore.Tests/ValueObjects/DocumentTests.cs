using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void Deve_retornar_uma_noitificacao_quando_documento_for_invalido()
        {
            var document = new Document("1234567890");
            Assert.AreEqual(true, document.Invalid);
        }

        [TestMethod]
        public void Nao_deve_retornar_uma_noitificacao_quando_documento_for_valido()
        {
            var document = new Document("11252529015");
            Assert.AreEqual(true, document.IsValid);
        }
    }
}