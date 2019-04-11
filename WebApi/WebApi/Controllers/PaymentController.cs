namespace WebApi.Controllers
{
	using System;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Options;
	using PaymentCwi.Models;
	using PaymentCwi.Models.Enum;
	using PaymentCwi.Services;
	using WebApi.Models;
	using WebApi.Repositories;

	/// <summary>
	/// The payment controller.
	/// </summary>
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class PaymentController : Controller
	{
		/// <summary>
		/// The order braspag repository.
		/// </summary>
		private readonly IOrderBraspagRepository orderBraspagRepository;

		/// <summary>
		/// The branchs repository.
		/// </summary>
		private readonly IBranchsRepository branchsRepository;

		/// <summary>
		/// The payment status repository.
		/// </summary>
		private readonly IPaymentStatusRepository paymentStatusRepository;

		/// <summary>
		/// The settings.
		/// </summary>
		private readonly Settings settings;

		/// <summary>
		/// Initializes a new instance of the PaymentController class.
		/// </summary>
		/// <param name="orderBraspagRepository">The order braspag repository.</param>
		/// <param name="branchsRepository">The branch repository.</param>
		/// <param name="optionsSnapshot">The Settings</param>
		/// <param name="paymentStatusRepository">The payment status repository.</param>
		public PaymentController(IOrderBraspagRepository orderBraspagRepository, IBranchsRepository branchsRepository, IOptionsSnapshot<Settings> optionsSnapshot, IPaymentStatusRepository paymentStatusRepository)
		{
			this.orderBraspagRepository = orderBraspagRepository;
			this.branchsRepository = branchsRepository;
			this.paymentStatusRepository = paymentStatusRepository;
			this.settings = optionsSnapshot.Value;
		}

		// POST api/payment

		/// <summary>The notification post.</summary>
		/// <param name="notificationPost">The notification post object.</param>
		/// <returns>The <see cref="IActionResult"/>.</returns>
		[HttpPost(Name = nameof(NotificationPost))]
		[Produces("application/json")]
		public IActionResult NotificationPost([FromBody]NotificationPost notificationPost)
		{
			if (notificationPost == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (notificationPost.ChangeType == ChangeTypeNotificationEnum.StatusChanged)
			{
				var ordersBrasPag = this.orderBraspagRepository.GetFirstOrDefault(x => x.PaymentGuid == notificationPost.PaymentId);

				if (ordersBrasPag != null)
				{
					var responseService = this.ResponseService(ordersBrasPag);

					var paymentStatus =
						paymentStatusRepository.GetFirstOrDefault(x => x.GatewayResponseCode == responseService.Payment.Status);
					SaveOrderBraspagLog(ordersBrasPag, paymentStatus);

					return Ok(new { Message = "Sistema atualizado com sucesso!" });

				}
			}

			return Ok(new { Message = "Tipo de atualização não suportado!" });
		}

		/// <summary>The response service.</summary>
		/// <param name="ordersBrasPag">The orders bras pag.</param>
		/// <returns>The <see cref="Sale"/>.</returns>
		private Sale ResponseService(OrdersBrasPag ordersBrasPag)
		{
			var branch = this.branchsRepository.GetFirstOrDefault(x => x.BranchId == ordersBrasPag.BranchId);

			var paymentService = new PaymentApiService(this.settings.QueryUrl);
			var authentication = this.MerchantAuthentication(ordersBrasPag, branch);
			var responseService = paymentService.Get(new Guid(ordersBrasPag.PaymentGuid), authentication);

			return responseService;
		}

		/// <summary>The merchant authentication.</summary>
		/// <param name="ordersBrasPag">The orders bras pag.</param>
		/// <param name="branch">The branch.</param>
		/// <returns>The <see cref="MerchantAuthentication"/>.</returns>
		private MerchantAuthentication MerchantAuthentication(OrdersBrasPag ordersBrasPag, Branchs branch)
		{
			var authentication = new MerchantAuthentication();
			if (ordersBrasPag.Value > 300)
			{
				authentication.MerchantId = new Guid(branch.MerchantIdCyber);
				authentication.MerchantKey = branch.MerchantKeyCyber;
			}
			else
			{
				authentication.MerchantId = new Guid(branch.MerchantId);
				authentication.MerchantKey = branch.MerchantKey;
			}

			return authentication;
		}

		/// <summary>The save order braspag log.</summary>
		/// <param name="ordersBrasPag">The orders bras pag.</param>
		private void SaveOrderBraspagLog(OrdersBrasPag ordersBrasPag, PaymentStatus paymentStatus)
		{
			ordersBrasPag.OrderBraspagId = null;
			ordersBrasPag.PaymentStatusId = paymentStatus.PaymentStatusId;
			ordersBrasPag.CreatedDate = DateTime.Now;
			ordersBrasPag.Details = "Notificação da Braspag";
			ordersBrasPag.OrderStatus = null;

			this.orderBraspagRepository.Insert(ordersBrasPag);
		}
	}
}