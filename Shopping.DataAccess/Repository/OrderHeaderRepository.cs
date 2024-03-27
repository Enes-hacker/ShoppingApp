using Shopping.DataAccess.Data;
using Shopping.DataAccess.Repository.IRepository;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        /*public void Save()
        {
            _db.SaveChanges();
        }*/

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string OrderStatus, string? PaymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = OrderStatus;
                if (!string.IsNullOrEmpty(PaymentStatus))
                {
                    orderFromDb.PaymentStatus = PaymentStatus;

				}
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string paymentIntendId)
        {
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
			if (!string.IsNullOrEmpty(sessionId))
			{
				orderFromDb.SessionId = sessionId;
			}
			
			if (!string.IsNullOrEmpty(paymentIntendId))
			{
				orderFromDb.PaymentIntentId = paymentIntendId;
                orderFromDb.PaymentDate = DateTime.Now;

			}
		}

	}
}
