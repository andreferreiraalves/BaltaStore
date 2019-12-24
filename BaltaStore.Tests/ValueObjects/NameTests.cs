using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void Deve_retornar_uma_notificacao_quando_nome_nao_valido()
        {
            var name = new Name("", "oliveira");

            Assert.AreEqual(true, name.Invalid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}