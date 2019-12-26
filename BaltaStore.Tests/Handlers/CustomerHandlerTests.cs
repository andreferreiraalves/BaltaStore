using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void Deve_registrar_um_cliente_quando_comando_valido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "André";
            command.LastName = "Ferreira";
            command.Document = "11252529015";
            command.Email = "andre.ferreira.alves@gmail.com";
            command.Phone = "17999999999";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}