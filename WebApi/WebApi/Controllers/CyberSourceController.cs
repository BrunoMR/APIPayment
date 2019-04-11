namespace WebApi.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using WebApi.Models;
    using WebApi.Repositories;

    /// <summary>
    /// The cyber source controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CyberSourceController : Controller
    {
        /// <summary>
        /// The order braspag repository.
        /// </summary>
        private readonly IOrderBraspagRepository orderBraspagRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CyberSourceController"/> class.
        /// </summary>
        /// <param name="orderBraspagRepository">
        /// The order braspag repository.
        /// </param>
        public CyberSourceController(IOrderBraspagRepository orderBraspagRepository)
        {
            this.orderBraspagRepository = orderBraspagRepository;
        }

        /// <summary>The update status.</summary>
        /// <param name="notifcation">The notifcation.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPost(Name = "UpdateStatus")]
        public IActionResult UpdateStatus([FromBody] CaseManagementOrderStatusToPostToClient notifcation)
        {
            if (notifcation == null)
            {
                return BadRequest();
            }

            var cybersourceUpdate = Mapper.Map<CybersourceUpdate>(notifcation);

            var firstOrDefault = this.orderBraspagRepository.GetFirstOrDefault(x => x.FraudAnalysisId == cybersourceUpdate.AntiFraudTransactionId);

            if (firstOrDefault != null)
            {
                this.SaveOrderBraspagLog(firstOrDefault, cybersourceUpdate);

                return Ok(new
                {
                    Message = "Sistema atualizado com sucesso!"
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Sistema não atualizado com sucesso!"
                });
            }
        }

        /// <summary>The save order braspag log.</summary>
        /// <param name="ordersBrasPag">The orders bras pag.</param>
        /// <param name="cybersourceUpdate">The cybersource update.</param>
        private void SaveOrderBraspagLog(OrdersBrasPag ordersBrasPag, CybersourceUpdate cybersourceUpdate)
        {
            ordersBrasPag.OrderBraspagId = null;
            ordersBrasPag.FraudAnalysisStatus = (int)cybersourceUpdate.NewDecision;
            ordersBrasPag.CreatedDate = DateTime.Now;
            ordersBrasPag.Details = "Resposta da CyberSource";
            ordersBrasPag.OrderStatus = null;

            this.orderBraspagRepository.Insert(ordersBrasPag);
        }
    }
}