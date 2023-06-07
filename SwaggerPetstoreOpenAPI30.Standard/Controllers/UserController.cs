// <copyright file="UserController.cs" company="APIMatic">
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
    /// UserController.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        internal UserController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User CreateUser(
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null)
            => CoreHelper.RunTask(CreateUserAsync(id, username, firstName, lastName, email, password, phone, userStatus));

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> CreateUserAsync(
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.User>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/user")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("id", id))
                      .Form(_form => _form.Setup("username", username))
                      .Form(_form => _form.Setup("firstName", firstName))
                      .Form(_form => _form.Setup("lastName", lastName))
                      .Form(_form => _form.Setup("email", email))
                      .Form(_form => _form.Setup("password", password))
                      .Form(_form => _form.Setup("phone", phone))
                      .Form(_form => _form.Setup("userStatus", userStatus))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.User>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User CreateUsersWithListInput(
                List<Models.User> body = null)
            => CoreHelper.RunTask(CreateUsersWithListInputAsync(body));

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> CreateUsersWithListInputAsync(
                List<Models.User> body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.User>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/user/createWithList")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("0", CreateErrorCase("successful operation", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.User>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="username">Optional parameter: The user name for login.</param>
        /// <param name="password">Optional parameter: The password for login in clear text.</param>
        /// <returns>Returns the string response from the API call.</returns>
        public string LoginUser(
                string username = null,
                string password = null)
            => CoreHelper.RunTask(LoginUserAsync(username, password));

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="username">Optional parameter: The user name for login.</param>
        /// <param name="password">Optional parameter: The password for login in clear text.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> LoginUserAsync(
                string username = null,
                string password = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<string>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/user/login")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("username", username))
                      .Query(_query => _query.Setup("password", password))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid username/password supplied", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Logs out current logged in user session.
        /// </summary>
        public void LogoutUser()
            => CoreHelper.RunVoidTask(LogoutUserAsync());

        /// <summary>
        /// Logs out current logged in user session.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task LogoutUserAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/user/logout")
                  .WithAuth("global"))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get user by user name.
        /// </summary>
        /// <param name="name">Required parameter: The name that needs to be fetched. Use user1 for testing..</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User GetUserByName(
                string name)
            => CoreHelper.RunTask(GetUserByNameAsync(name));

        /// <summary>
        /// Get user by user name.
        /// </summary>
        /// <param name="name">Required parameter: The name that needs to be fetched. Use user1 for testing..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> GetUserByNameAsync(
                string name,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.User>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/user/{name}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("name", name))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid username supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("User not found", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.User>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="name">Required parameter: name that need to be deleted.</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        public void UpdateUser(
                string name,
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null)
            => CoreHelper.RunVoidTask(UpdateUserAsync(name, id, username, firstName, lastName, email, password, phone, userStatus));

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="name">Required parameter: name that need to be deleted.</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdateUserAsync(
                string name,
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/user/{name}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("name", name))
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("id", id))
                      .Form(_form => _form.Setup("username", username))
                      .Form(_form => _form.Setup("firstName", firstName))
                      .Form(_form => _form.Setup("lastName", lastName))
                      .Form(_form => _form.Setup("email", email))
                      .Form(_form => _form.Setup("password", password))
                      .Form(_form => _form.Setup("phone", phone))
                      .Form(_form => _form.Setup("userStatus", userStatus))))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="name">Required parameter: The name that needs to be deleted.</param>
        public void DeleteUser(
                string name)
            => CoreHelper.RunVoidTask(DeleteUserAsync(name));

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="name">Required parameter: The name that needs to be deleted.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteUserAsync(
                string name,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/user/{name}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("name", name))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid username supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("User not found", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);
    }
}