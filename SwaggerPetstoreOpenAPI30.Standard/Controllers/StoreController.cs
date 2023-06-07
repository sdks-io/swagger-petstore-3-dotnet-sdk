// <copyright file="StoreController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Authentication;
    using SwaggerPetstoreOpenAPI30.Standard.Exceptions;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Client;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// StoreController.
    /// </summary>
    public class StoreController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreController"/> class.
        /// </summary>
        internal StoreController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <returns>Returns the Dictionary of string, int response from the API call.</returns>
        public Dictionary<string, int> GetInventory()
            => CoreHelper.RunTask(GetInventoryAsync());

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Dictionary of string, int response from the API call.</returns>
        public async Task<Dictionary<string, int>> GetInventoryAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Dictionary<string, int>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/store/inventory")
                  .WithAuth("global"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Dictionary<string, int>>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Place a new order in the store.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="petId">Optional parameter: Example: .</param>
        /// <param name="quantity">Optional parameter: Example: .</param>
        /// <param name="shipDate">Optional parameter: Example: .</param>
        /// <param name="orderStatus">Optional parameter: Order Status.</param>
        /// <param name="complete">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public Models.Order PlaceOrder(
                long? id = null,
                long? petId = null,
                int? quantity = null,
                DateTime? shipDate = null,
                Models.OrderStatusEnum? orderStatus = Models.OrderStatusEnum.Approved,
                bool? complete = null)
            => CoreHelper.RunTask(PlaceOrderAsync(id, petId, quantity, shipDate, orderStatus, complete));

        /// <summary>
        /// Place a new order in the store.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="petId">Optional parameter: Example: .</param>
        /// <param name="quantity">Optional parameter: Example: .</param>
        /// <param name="shipDate">Optional parameter: Example: .</param>
        /// <param name="orderStatus">Optional parameter: Order Status.</param>
        /// <param name="complete">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public async Task<Models.Order> PlaceOrderAsync(
                long? id = null,
                long? petId = null,
                int? quantity = null,
                DateTime? shipDate = null,
                Models.OrderStatusEnum? orderStatus = Models.OrderStatusEnum.Approved,
                bool? complete = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Order>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/store/order")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("id", id))
                      .Form(_form => _form.Setup("petId", petId))
                      .Form(_form => _form.Setup("quantity", quantity))
                      .Form(_form => _form.Setup("shipDate", shipDate.HasValue ? shipDate.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") : null))
                      .Form(_form => _form.Setup("orderStatus", (orderStatus.HasValue) ? ApiHelper.JsonSerialize(orderStatus.Value).Trim('\"') : "approved"))
                      .Form(_form => _form.Setup("complete", complete))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("405", CreateErrorCase("Invalid input", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.Order>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of order that needs to be fetched.</param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public Models.Order GetOrderById(
                long orderId)
            => CoreHelper.RunTask(GetOrderByIdAsync(orderId));

        /// <summary>
        /// For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of order that needs to be fetched.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public async Task<Models.Order> GetOrderByIdAsync(
                long orderId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Order>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/store/order/{orderId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("orderId", orderId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Order not found", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.Order>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of the order that needs to be deleted.</param>
        public void DeleteOrder(
                long orderId)
            => CoreHelper.RunVoidTask(DeleteOrderAsync(orderId));

        /// <summary>
        /// For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of the order that needs to be deleted.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteOrderAsync(
                long orderId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/store/order/{orderId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("orderId", orderId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Order not found", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);
    }
}