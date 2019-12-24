using System.Linq;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyBoard;
        private Product _chair;
        private Product _monitor;

        private Customer _customer;
        private Order _orderValid;

        public OrderTests()
        {
            var name = new Name("André", "Ferreira");
            var document = new Document("11252529015");
            var email = new Email("andre.ferreira.alves@gmail.com");
            _customer = new Customer(name, document, email, "17999999999");
            _orderValid = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyBoard = new Product("Teclado Gamer", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        }

        [TestMethod]
        public void Deve_criar_um_pedido_quando_for_valido()
        {
            Assert.AreEqual(true, _orderValid.IsValid);
        }

        [TestMethod]
        public void Status_deve_retornar_criado_quando_um_novo_pedido()
        {
            Assert.AreEqual(EOrderStatus.Created, _orderValid.Status);
        }

        [TestMethod]
        public void Deve_retornar_dois_quando_adicionado_dois_itens_validos()
        {
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_mouse, 5);

            Assert.AreEqual(2, _orderValid.Items.Count);
        }

        [TestMethod]
        public void Deve_retornar_cinco_quando_adicionado_item()
        {
            _orderValid.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.QuantityOnHand);
        }

        [TestMethod]
        public void Deve_retornar_um_numero_quando_confirmado_pedido()
        {
            _orderValid.Place();
            Assert.AreNotEqual("", _orderValid.Number);
        }

        [TestMethod]
        public void Deve_retornar_pago_quando_pedido_pago()
        {
            _orderValid.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _orderValid.Status);
        }

        [TestMethod]
        public void Deve_retornar_dois_quando_comprado_dez_produtos()
        {
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);

            _orderValid.Ship();
            Assert.AreEqual(2, _orderValid.Deliveries.Count);
        }

        [TestMethod]
        public void Status_deve_retornar_cancelado_quando_a_order_for_cancelada()
        {
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);
            _orderValid.AddItem(_monitor, 5);

            _orderValid.Ship();

            _orderValid.Cancel();

            _orderValid.Deliveries.ToList().ForEach(x => Assert.AreEqual(EDeliveryStatus.Canceled, x.Status));
        }

        // [TestMethod]
        // public void Status_deve_retornar_entregue_quando_a_order_for_entregue()
        // {
        //     Assert.Fail();
        // }
    }
}