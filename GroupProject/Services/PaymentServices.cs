using BusinessObjects.Models;
using DataAccessLayers.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService : IPaymentServices
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public Task<bool> AddAsync(Payment payment) => _paymentRepository.AddAsync(payment);

        public Task<IEnumerable<Payment>> GetAllAsync() => _paymentRepository.GetAllAsync();

        public Task<Payment> GetByIdAsync(int id) => _paymentRepository.GetByIdAsync(id);

        public bool Remove(int id) => _paymentRepository.Remove(id);

        public bool Update(Payment payment) => _paymentRepository.Update(payment);
    }
}
